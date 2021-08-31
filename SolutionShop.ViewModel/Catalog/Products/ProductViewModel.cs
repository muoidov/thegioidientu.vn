using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SolutionShop.ViewModel.Catalog.Products
{
    public class ProductViewModel
    {
        [Display(Name = "Mã SP")]
        public int Id { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { get; set; }

        [Display(Name = "Tồn kho")]
        public int Stock { get; set; }

        [Display(Name = "Lượt xem")]
        public int ViewCount { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { set; get; }

        [Display(Name = "Mô tả")]
        public string Description { set; get; }

        [Display(Name = "Thông tin sản phẩm")]
        public string Details { set; get; }

        [Display(Name = "Tag Des")]
        public string SeoDescription { set; get; }

        [Display(Name = "Tag title")]
        public string SeoTitle { set; get; }

        [Display(Name = "Alias")]
        public string SeoAlias { get; set; }

        [Display(Name = "Quốc gia")]
        public string LanguageId { set; get; }

        [Display(Name = "Phân loại")]
        public List<string> Categories { get; set; } = new List<string>();

        [Display(Name = "Đường dẫn ảnh")]
        public string ThumbnailImage { get; set; }
    }
}