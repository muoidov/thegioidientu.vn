using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Catalog.Categories;
using SolutionShop.ViewModel.Catalog.Categories;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatergoryService _categoryService;

        public CategoriesController(ICatergoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _categoryService.GetAll(languageId);
            return Ok(products);
        }

        [HttpGet("{languageId}/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var category = await _categoryService.GetById(languageId, id);
            return Ok(category);
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CategoryAllModel request)
        {
            var category = await _categoryService.Create(request);
            return Ok(category);
        }

        [HttpDelete("Delete")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var category = await _categoryService.Delete(id);
            return Ok(category);
        }

        [HttpGet("GetParent")]
        [AllowAnonymous]
        public async Task<IActionResult> GetParent()
        {
            var category = await _categoryService.GetParentId();
            return Ok(category);
        }

        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] CatergoryPagingRequest request)
        {
            var category = await _categoryService.GetAllPaging(request);
            return Ok(category);
        }
    }
}