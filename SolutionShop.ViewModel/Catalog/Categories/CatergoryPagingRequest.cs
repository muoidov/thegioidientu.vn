using SolutionShop.ViewModel.Common;

namespace SolutionShop.ViewModel.Catalog.Categories
{
    public class CatergoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }
    }
}