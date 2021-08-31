using System.ComponentModel.DataAnnotations;

namespace SolutionShop.ViewModel.Catalog.Categories
{
    public class CategoryAllModel
    {
        [Display(Name = "Mã Phân loại")]
        public int Id { get; set; }

        [Display(Name = "Vị trí sắp xếp")]
        public int SortOrder { get; set; }

        [Display(Name = "Có hiển thị hay không")]
        public bool IsShowHome { get; set; }

        [Display(Name = "Lớp phân loại lớn")]
        public int? ParenId { get; set; }

        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

        [Display(Name = "Tên danh mục")]
        public string Name { set; get; }

        [Display(Name = "SeoDescription")]
        public string SeoDescription { set; get; }

        [Display(Name = "SeoTitle")]
        public string SeoTitle { set; get; }

        [Display(Name = "Ngôn ngữ")]
        public string LanguageId { set; get; }

        [Display(Name = "SeoAlias")]
        public string SeoAlias { set; get; }
    }
}