using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.Sales;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<int> Create(OrderCreateRequest request);

        Task<int> Delete(int orderId);

        OrderViewModel GetById(OrderViewModel request);

        Task<bool> UpdateStatus(int orderId, int status);

        Task<PagedResult<OrderViewModel>> GetAllPaging(OrderPagingRequest request);

        Task<PagedResult<OrderViewModel>> GetChart(OrderPagingRequest request);
    }
}