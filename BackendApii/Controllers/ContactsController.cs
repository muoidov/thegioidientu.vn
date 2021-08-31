using Microsoft.AspNetCore.Mvc;
using SolutionShop.Application.Contact;
using SolutionShop.ViewModel.System.Contact;
using System.Threading.Tasks;

namespace BackendApii.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _contactService.GetAll();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderId = await _contactService.Create(request);
            if (orderId == 0)
                return BadRequest();
            return Ok("Gửi thành công");
        }
    }
}