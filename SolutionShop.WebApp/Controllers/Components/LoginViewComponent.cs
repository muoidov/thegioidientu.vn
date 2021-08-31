using Microsoft.AspNetCore.Mvc;
using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Users;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AdminApp.Components
{
    public class LoginViewComponent : ViewComponent
    {
        
        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = new LoginRequest();
            return Task.FromResult((IViewComponentResult)View("Index", model));
        }
    }
}