using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SolutionShop.ApiIntegration;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.Sales;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        private readonly IConfiguration _configuration;

        public OrderController(IConfiguration configuration, IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(int status, string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var LanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (LanguageId == null)
            {
                LanguageId = "vi-VN";
                HttpContext.Session.SetString(SystemConstants.AppSettings.DefaultLanguageId, LanguageId);
            }
            var request = new OrderPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = LanguageId,
                Status = status
            };
            var data = await _orderApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

            var rs = new List<System.Web.Mvc.SelectListItem>() {
                new System.Web.Mvc.SelectListItem {Text="Chờ xác nhận",Value="1",Selected=(status==1?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Vận chuyển",Value="2",Selected=(status==2?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Đã giao hàng",Value="3",Selected=(status==3?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Hủy đơn",Value="4",Selected=(status==4?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Trả lại hàng",Value="5",Selected=(status==5?true:false) },
            };
            ViewBag.Status = rs.Select(x => new SelectListItem()
            {
                Text = x.Text,
                Value = x.Value,
                Selected = x.Selected
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] OrderCreateRequest request)

        {
            if (!ModelState.IsValid)
                return View(request);
            var result = await _orderApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới đơn hàng thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm đơn hàng thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Editt(int status, int orderId)
        {
            var rs = new List<System.Web.Mvc.SelectListItem>() {
                new System.Web.Mvc.SelectListItem {Text="Chờ xác nhận",Value="1",Selected=(status==1?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Vận chuyển",Value="2",Selected=(status==2?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Đã giao hàng",Value="3",Selected=(status==3?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Hủy đơn",Value="4",Selected=(status==4?true:false) },
                new System.Web.Mvc.SelectListItem {Text="Trả lại hàng",Value="5",Selected=(status==5?true:false) },
            };
            ViewBag.Status = rs.Select(x => new SelectListItem()
            {
                Text = x.Text,
                Value = x.Value,
                Selected = x.Selected
            });
            ViewBag.orderId = orderId;

            return View(orderId);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(int orderId, int status)

        {
            if (!ModelState.IsValid)
                return View(orderId);
            var result = await _orderApiClient.UpdateStatus(orderId, status);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật thất bại");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return View();
            var rs = await _orderApiClient.Delete(id);
            if (rs)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", rs.ToString());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(OrderViewModel request)
        {
            var rs = await _orderApiClient.GetById(request);
            return View(rs);
        }
    }
}