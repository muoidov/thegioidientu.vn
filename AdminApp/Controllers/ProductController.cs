using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Catalog.Products;
using SolutionShop.ViewModel.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;

        private readonly ICatergoryApiClient _categoryApiClient;

        public ProductController(IConfiguration configuration, IProductApiClient productApiClient, ICatergoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 10, string sort = "AZ")
        {
            var LanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (LanguageId == null)
            {
                LanguageId = "vi-VN";
                HttpContext.Session.SetString(SystemConstants.AppSettings.DefaultLanguageId, LanguageId);
            }
            var sessions = HttpContext.Session.GetString("Token");
            var request = new MGetProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = LanguageId,
                CategoryId = categoryId
            };
            var data = await _productApiClient.GetPagings(request, sort);
            var categories = await _categoryApiClient.GetAll(LanguageId);
            ViewBag.Keyword = keyword;
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var roleAssignRequest = await GetCategoryAssignRequest(id);
            return View(roleAssignRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetCategoryAssignRequest(request.Id);
            return View(roleAssignRequest);
        }

        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var productObj = await _productApiClient.GetById(id, languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var categoryAssignRequest = new CategoryAssignRequest();
            foreach (var role in categories)
            {
                categoryAssignRequest.Categories.Add(new SelectItem()
                {
                    Id = role.Id.ToString(),
                    Name = role.Name,
                    Selected = productObj.Categories.Contains(role.Name)
                });
            }
            return categoryAssignRequest;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)

        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["result"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var product = await _productApiClient.GetById(id, languageId);
            var editVm = new ProductUpdateRequest()
            {
                Id = product.Id,
                Description = product.Description,
                Details = product.Details,
                Name = product.Name,
                SeoAlias = product.SeoAlias,
                SeoDescription = product.SeoDescription,
                SeoTitle = product.SeoTitle
            };
            return View(editVm);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)

        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _productApiClient.UpdateProduct(request);
            if (result)
            {
                TempData["result"] = "CN sản phẩm thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "CN phẩm thất bại");
            return View(request);
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    return View(new UserDeleteRequest()
        //    {
        //        Id = id
        //    });
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _productApiClient.DeleteProduct(id);
            if (rs)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", rs.ToString());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var LanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var rs = await _productApiClient.GetById(id, LanguageId);
            return View(rs);
        }
    }
}