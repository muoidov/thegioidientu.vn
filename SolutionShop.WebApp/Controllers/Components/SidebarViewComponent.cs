using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SolutionShop.Utilities.Constants;
using SolutionShop.WebApp.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers.Components
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ICatergoryApiClient _catergoryApiClient;

        public SidebarViewComponent(ICatergoryApiClient categoryApiClient)
        {
            _catergoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            ViewBag.Price = $"{ currentCart.Sum(x => x.Price)}đ";
            ViewBag.CountItem = currentCart.Sum(x => x.Quantity);

            var items = await _catergoryApiClient.GetAll(CultureInfo.CurrentCulture.Name);
            return View(items);
        }
    }
}