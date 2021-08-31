using System.ComponentModel.DataAnnotations;

namespace SolutionShop.ViewModel.System.Contact
{
    public class ContactViewModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập mail")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string PhoneNumber { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập nội dung")]
        public string Message { set; get; }
    }
}