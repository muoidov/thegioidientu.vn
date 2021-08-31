using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolutionShop.Data.EF;
using SolutionShop.Data.Entities;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly Shopdbcontext _context;

        public UserService(Shopdbcontext context, UserManager<AppUser> userManage, SignInManager<AppUser> signInManage, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManage;
            _signInManager = signInManage;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return new ApiError<string>("User khong ton tai");
            var rs = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!rs.Succeeded)
            {
                return new ApiSuccessResult<string>("Dang nhap khong thanh cong");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            var res = new JwtSecurityTokenHandler().WriteToken(token);
            return new ApiSuccessResult<string>(res);
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.KeyWord))
            {
                query = query.Where(x => x.UserName.Contains(request.KeyWord) || x.PhoneNumber.Contains
                  (request.KeyWord));
            }
            int totalRow = await query.CountAsync();
            //.Skip((request.PageIndex - 1) * request.PageSize)
            //
            var data = await query.Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id,
                    UserName = x.UserName
                }).ToListAsync();
            //chon project

            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                Items = data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiError<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiError<bool>("Emai đã tồn tại");
            }

            user = new AppUser()
            {
                Dob = request.Dob,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, request.PassWord);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiError<bool>("Đăng ký không thành công");
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Dob = request.Dob;
            if (request.Dob == null)
            {
                user.Dob = DateTime.Now;
            }
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiError<bool>("Update o thanh cong");
        }

        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiError<UserVm>("User o ton tai");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = new UserVm()
            {
                Dob = user.Dob,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Roles = roles
            };
            return new ApiSuccessResult<UserVm>(userVm);
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiError<bool>("User o ton tai");
            }
            var rs = await _userManager.DeleteAsync(user);
            if (rs.Succeeded)
                return new ApiSuccessResult<bool>();
            return new ApiError<bool>("Ko xóa được");
        }

        public async Task<ApiResult<bool>> RoleAsign(Guid id, RoleAsignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiError<bool>("Tài khoản không tồn tại");
            }
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> ForgotPassword(ForgotPasswordRequest request)
        {
            var rs = new ForgotPassword();
            rs.UserName = request.UserName;
            rs.Email = request.Email;
            rs.Description = "Quên mật khẩu";
            _context.ForgotPasswords.Add(rs);
            var rt = await _context.SaveChangesAsync();
            if (rt != 0)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiError<bool>("Có lỗi xảy ra");
        }

        public async Task<ApiResult<List<ForgotPassword>>> GetAllNotice()
        {
            var rs = _context.ForgotPasswords;

            var data = rs.Select(x => new ForgotPassword()
            { UserName = x.UserName, Description = x.Description, Email = x.Email }).ToList();

            return new ApiSuccessResult<List<ForgotPassword>>(data);
        }
    }
}