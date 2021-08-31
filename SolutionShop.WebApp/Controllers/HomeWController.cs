using ApiIntegration;
using ApiIntegration.Services;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolutionShop.Utilities.Constants;
using SolutionShop.ViewModel.System.Contact;
using SolutionShop.WebApp.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers
{
    public class HomeWController : Controller
    {
        private readonly ILogger<HomeWController> _logger;
        private readonly ISharedCultureLocalizer _loc;
        private readonly ISlideApiClient _slideApiClient;
        private readonly IProductApiClient _produtApiClient;
        private readonly IContactApiClient _contactApiClient;
        private readonly ICatergoryApiClient _categoryApiClient;

        public HomeWController(ISharedCultureLocalizer loc,
            ILogger<HomeWController> logger,
            ISlideApiClient slideApiClient,
            IProductApiClient produtApiClient, ICatergoryApiClient categoryApiClient, IContactApiClient contactApiClient)
        {
            _logger = logger;
            _loc = loc;
            _slideApiClient = slideApiClient;
            _produtApiClient = produtApiClient;
            _contactApiClient = contactApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var culture = CultureInfo.CurrentCulture.Name;

            var viewModel = new HomeViewModel()
            {
                Slides = await _slideApiClient.GetAll(),
                FeaturedProducts = await _produtApiClient.GetFeaturedProducts
                (culture, SystemConstants.ProductSettings.NumberOfFeaturedProduct),
                LastestProducts = await _produtApiClient.GetLastestProducts
                (culture, SystemConstants.ProductSettings.NumberOfLastestProduct)
            };

            return View(viewModel);
        }

        public IActionResult Delivery()
        {
            return View();
        }

        public IActionResult Contact()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }

        public IActionResult Term()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Legal()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Blog1()
        {
            return View();
        }

        public IActionResult Blog2()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactViewModel request)
        {
            if (!ModelState.IsValid)
                return View("Contact");
            var rs = await _contactApiClient.Create(request);

            if (rs)
            {
                TempData["result"] = "Gửi thành công";
                return RedirectToAction("Contact");
            }
            return BadRequest("Gửi không thành công");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
            });
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}