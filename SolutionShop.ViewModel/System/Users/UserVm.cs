using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SolutionShop.ViewModel.System.Users
{
    public class UserVm
    {
        public Guid Id { get; set; }
        [Display(Name="Tên")]
        public string FirstName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Hòm thư")]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime Dob { get; set; }
        [Display(Name = "Quyền")]
        public IList<string> Roles { get; set; }
    }
}
