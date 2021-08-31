using SolutionShop.ViewModel.Common;

namespace SolutionShop.ViewModel.Catalog.Products
{
    public class MGetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}