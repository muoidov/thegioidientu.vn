using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SolutionShop.ViewModel.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name = "Giá")]

        public decimal Price { get; set; }
        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { get; set; }
        [Display(Name = "Kho")]
        public int Stock { get; set; }
        [Required(ErrorMessage="Nhập tên vào")]
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
        [Display(Name = "Region")]
        public string LanguageId { set; get; }
        [Display(Name = "Ảnh")]
        public IFormFile ThumbnailImage { get; set; }
    }

}
