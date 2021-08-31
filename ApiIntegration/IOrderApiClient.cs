using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.Sales;
using System.Threading.Tasks;

namespace SolutionShop.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<PagedResult<OrderViewModel>> GetPagings(OrderPagingRequest request);

        Task<PagedResult<OrderViewModel>> GetChart(OrderPagingRequest request);

        Task<bool> Create(OrderCreateRequest request);

        Task<bool> UpdateStatus(int orderId, int status);

        Task<OrderViewModel> GetById(OrderViewModel request);

        Task<bool> Delete(int id);
    }
}