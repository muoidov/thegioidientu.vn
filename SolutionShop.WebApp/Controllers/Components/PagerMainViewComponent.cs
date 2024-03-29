﻿using Microsoft.AspNetCore.Mvc;
using SolutionShop.ViewModel.Common;
using System.Threading.Tasks;

namespace AdminApp.Components
{
    public class PagerMainViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}