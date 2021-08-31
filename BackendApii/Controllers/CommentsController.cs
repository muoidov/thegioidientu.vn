using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Common.Comments;
using SolutionShop.ViewModel.Common;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: CommentsController
        [HttpGet]
        public async Task<IActionResult> GetByProduct([FromQuery] int productId)
        {
            var cm = await _commentService.GetByProduct(productId);
            return Ok(cm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _commentService.Create(request);
            if (comment == 0)
                return BadRequest();
            return Ok("Bình luận thành công");
        }
    }
}