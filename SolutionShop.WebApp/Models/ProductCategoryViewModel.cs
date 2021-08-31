using SolutionShop.ViewModel.Catalog.Categories;

using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;

namespace SolutionShop.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryVm Category { get; set; }
        public PagedResult<ProductViewModel> Products { get; set; }
    }
}