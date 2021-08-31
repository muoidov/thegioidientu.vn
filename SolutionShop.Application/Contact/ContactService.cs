using SolutionShop.Data.EF;
using SolutionShop.ViewModel.System.Contact;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.Application.Contact
{
    public class ContactService : IContactService
    {
        private readonly Shopdbcontext _context;

        public ContactService(Shopdbcontext context)
        {
            _context = context;
        }

        public async Task<int> Create(ContactViewModel request)
        {
            var contact = new Data.Entities.Contact()

            {
                Email = request.Email,
                Message = request.Message,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Status = Data.Enums.Status.Active
            };
            _context.Contacts.Add(contact);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<ContactViewModel>> GetAll()
        {
            var query = _context.Contacts.Where(x => x.Id != 0);

            List<ContactViewModel> rs = new List<ContactViewModel>();
            foreach (var item in query)
            {
                ContactViewModel model = new ContactViewModel()
                {
                    Id = item.Id,
                    Email = item.Email,
                    Message = item.Message,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber
                };
                rs.Add(model);
            }
            return rs;
        }
    }
}