using Microsoft.AspNetCore.Mvc;
using SolutionShop.ApiIntegration;
using SolutionShop.ViewModel.Sales;
using System.Threading.Tasks;

namespace AdminApp.Components
{
    public class ChartViewComponent : ViewComponent
    {
        private readonly IOrderApiClient _orderApiClient;

        public ChartViewComponent(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var request = new OrderPagingRequest()
            {
                Keyword = "",
                PageIndex = 1,
                PageSize = 10,
                LanguageId = "vi-VN",
            };
            var data = await _orderApiClient.GetChart(request);
            return View("Index", data);
        }
    }
}