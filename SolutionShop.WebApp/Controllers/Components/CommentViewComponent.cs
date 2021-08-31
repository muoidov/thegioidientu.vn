using ApiIntegration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers.Components
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentApiClient _commentApiClient;

        public CommentViewComponent(ICommentApiClient commentApiClient)
        {
            _commentApiClient = commentApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productId)
        {
            var data = await _commentApiClient.GetByProduct(productId);
            return View("Index", data);
        }
    }
}