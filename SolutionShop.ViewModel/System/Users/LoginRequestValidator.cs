using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionShop.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Nhập tên đăng nhập");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Nhập mật khẩu").MinimumLength(6).WithMessage("Tối thiểu 6 ký tự mk");
        }
    }
}