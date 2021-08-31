using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SolutionShop.ViewModel.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public string LanguageId { set; get; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { set; get; }

        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        [Display(Name = "Chi tiết về sản phẩm")]
        public string Details { set; get; }

        [Display(Name = "Tag Des")]
        public string SeoDescription { set; get; }

        [Display(Name = "Tag Title")]
        public string SeoTitle { set; get; }

        [Display(Name = "Discount")]
        public bool? IsFeatured { get; set; }

        [Display(Name = "Alias")]
        public string SeoAlias { get; set; }

        [Display(Name = "Ảnh")]
        public IFormFile ThumbnailImage { get; set; }
    }
}