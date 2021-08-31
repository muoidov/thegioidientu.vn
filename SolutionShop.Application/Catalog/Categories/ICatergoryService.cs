using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolutionShop.Application.Catalog.Categories
{
    public interface ICatergoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<ApiResult<bool>> Create(CategoryAllModel request);

        Task<List<CategoryParent>> GetParentId();

        Task<int> Delete(int id);

        Task<PagedResult<CategoryAllModel>> GetAllPaging(CatergoryPagingRequest request);
    }
}