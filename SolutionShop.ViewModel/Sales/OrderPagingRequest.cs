using SolutionShop.ViewModel.Common;

namespace SolutionShop.ViewModel.Sales
{
    public class OrderPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
        public int? Status { get; set; }
    }
}