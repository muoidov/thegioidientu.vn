﻿using SolutionShop.Data.Entities;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolutionShop.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<UserVm>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAsign(Guid id, RoleAsignRequest request);

        Task<ApiResult<bool>> ForgotPassword(ForgotPasswordRequest request);

        Task<ApiResult<List<ForgotPassword>>> GetAllNotice();
    }
}