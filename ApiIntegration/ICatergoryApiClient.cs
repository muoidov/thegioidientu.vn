using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public interface ICatergoryApiClient
    {
        public Task<List<CategoryVm>> GetAll(string languageId);

        public Task<List<CategoryVm>> GetAllPaging(string languageId);

        public Task<CategoryVm> GetById(string languageId, int id);

        Task<PagedResult<CategoryAllModel>> GetPagings(CatergoryPagingRequest request);

        Task<List<CategoryParent>> GetParent();

        Task<ApiResult<bool>> Create(CategoryAllModel request);

        Task<bool> Delete(int id);
    }
}