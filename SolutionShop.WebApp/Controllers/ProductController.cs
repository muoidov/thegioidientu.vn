using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Catalog.Categories;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICatergoryApiClient _categoryApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(IProductApiClient productApiClient, ICatergoryApiClient categoryApiClient,
            IHttpContextAccessor httpContextAccessor)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Detail(int id, string culture)
        {
            if (id == 0)
            {
                id = int.Parse(_httpContextAccessor.HttpContext.Session.GetString(SystemConstants.Details.IdDetails).ToString());
            }
            _httpContextAccessor.HttpContext.Session.SetString(SystemConstants.Details.IdDetails, id.ToString());
            var product = await _productApiClient.GetById(id, culture);
            return View(new ProductDetailViewModel()
            {
                Product = product,
                Category = await _categoryApiClient.GetById(culture, id)
            });
        }

        public async Task<IActionResult> Category(string keyword, int id, string culture, int pageIndex = 1, string sort = "AZ")
        {
            if (culture == "vi")
            {
                culture = "vi-VN";
            }
            var products = await _productApiClient.GetPagings(new MGetProductPagingRequest
            {
                CategoryId = id,
                PageIndex = pageIndex,
                LanguageId = culture,
                PageSize = 10,
                Keyword = keyword
            }, sort);
            if (products.Items.Count == 0)
            {
                products.Items = new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Name="Không có sản phẩm nào",
                    }
                };
            };
            var model = new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(culture, id),
                Products = products
            };
            if (model.Category == null)
            {
                model.Category = new CategoryVm()
                {
                    Id = 0,
                    Name = "Phân loại",
                    ParentId = 0
                };
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(new ProductDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _productApiClient.DeleteProduct(request.Id);
            if (rs)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa không thành công");

            return View(request);
        }
    }
}