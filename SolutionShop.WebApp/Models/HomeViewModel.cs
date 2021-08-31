using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Ultilities.Slides;
using System.Collections.Generic;

namespace SolutionShop.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideVm> Slides { get; set; }
        public List<ProductViewModel> FeaturedProducts { get; set; }
        public List<ProductViewModel> LastestProducts { get; set; }
    }
}