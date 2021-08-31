using System.ComponentModel.DataAnnotations;

namespace SolutionShop.ViewModel.Common
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string Name { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Yêu cầu nội dung")]
        public string Content { get; set; }
    }
}