using ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.ViewModel.Common;
using System.Threading.Tasks;

namespace SolutionShop.WebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentApiClient _commentApiClient;

        public CommentController(ICommentApiClient commentApiClient)
        {
            _commentApiClient = commentApiClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Detail", "Product", ModelState);
            }
            var rs = await _commentApiClient.Create(request);
            if (rs)
            {
                return RedirectToAction("Detail", "Product");
            }
            return BadRequest("Không thể comment");
        }
    }
}