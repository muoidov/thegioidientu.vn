using FluentValidation;
using System;

namespace SolutionShop.ViewModel.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Chưa nhập tên").MaximumLength(60).WithMessage("Tên không được qua dài");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Chưa nhập họ").MaximumLength(50).WithMessage("Họ không được quá dài");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-1009)).WithMessage("Không thể lớn hơn 1000");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email không được rỗng").Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email không đúng định dạng");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Nhập đúng số điện thoại");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Tên đăng nhập bắt buộc");
            RuleFor(x => x.PassWord).NotEmpty().WithMessage("Nhập mật khẩu").MinimumLength(6).WithMessage("Mật khẩu tối thiểu 8 ký tự");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.PassWord != request.ConfirmPassword)
                {
                    context.AddFailure("Xác nhận mật khẩu không đúng");
                }
            });
        }
    }
}