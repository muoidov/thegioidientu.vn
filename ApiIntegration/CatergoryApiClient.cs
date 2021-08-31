using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegration.Services
{
    public class CatergoryApiClient : BaseApiClient, ICatergoryApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CatergoryApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<bool>> Create(CategoryAllModel request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var respone = await client.PostAsync($"/api/Categories/Create", httpContent);
            var rs = await respone.Content.ReadAsStringAsync();
            if (respone.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(rs);
            }
            return JsonConvert.DeserializeObject<ApiError<bool>>(rs);
        }

        public async Task<bool> Delete(int id)
        {
            return await Delete($"/api/Categories/Delete?id=" + id);
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            return await GetAsync<List<CategoryVm>>("/api/Categories?languageId=" + languageId);
        }

        public Task<List<CategoryVm>> GetAllPaging(string languageId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            return await GetAsync<CategoryVm>($"/api/Categories/{languageId}/{id}");
        }

        public async Task<PagedResult<CategoryAllModel>> GetPagings(CatergoryPagingRequest request)
        {
            string url = $"/api/Categories/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyWord={request.Keyword}&languageId={request.LanguageId}";
            var data = await GetAsync<PagedResult<CategoryAllModel>>(url);
            return data;
        }

        public async Task<List<CategoryParent>> GetParent()
        {
            return await GetAsync<List<CategoryParent>>($"/api/Categories/GetParent");
        }
    }
}