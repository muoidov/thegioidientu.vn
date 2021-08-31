using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Catalog.Categories;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class CatergoryController : Controller
    {
        private readonly ICatergoryApiClient _catergoryApiClient;
        private readonly IConfiguration _configuration;

        public CatergoryController(ICatergoryApiClient catergoryApiClient, IConfiguration configuration)
        {
            _catergoryApiClient = catergoryApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var LanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var request = new CatergoryPagingRequest()
            {
                Keyword = keyword,
                LanguageId = LanguageId,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _catergoryApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()

        {
            var categories = await _catergoryApiClient.GetParent();
            categories.Add(new CategoryParent() { Name = "Chọn", Id = null, Selected = true });
            ViewBag.phanloai = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.Selected
            }).ToList();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _catergoryApiClient.Delete(id);
            if (rs)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Có lỗi trong quá trình xóa");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAllModel request)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _catergoryApiClient.Create(request);
            if (rs.IsSuccessed)
            {
                TempData["result"] = "Tạo thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Lỗi");

            return View(request);
        }
    }
}