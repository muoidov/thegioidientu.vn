using AdminApp.Models;
using ApiIntegration;
using ApiIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolutionShop.ApiIntegration;
using SolutionShop.Utilities.Constants;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IContactApiClient _contactApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserApiClient userApiClient, IOrderApiClient orderApiClient, IContactApiClient contactApiClient)
        {
            _userApiClient = userApiClient;
            _orderApiClient = orderApiClient;
            _logger = logger;
            _contactApiClient = contactApiClient;
        }

        public IActionResult Index()
        {
            var user = User.Identity.Name;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotice()
        {
            var rs = await _userApiClient.GetAllNotice();
            if (!rs.IsSuccessed)
            {
                return BadRequest(rs);
            }

            return View(rs.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetResponse()
        {
            var rs = await _contactApiClient.GetAll();
            if (rs == null)
            {
                return BadRequest(rs);
            }

            return View(rs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Language(NavigationViewModel viewModel)
        {
            HttpContext.Session.SetString(SystemConstants.AppSettings.DefaultLanguageId, viewModel.CurrentLanguageId);
            return Redirect(viewModel.ReturnUrl);
        }
    }
}