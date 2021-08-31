using SolutionShop.ViewModel.System.Contact;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolutionShop.Application.Contact
{
    public interface IContactService
    {
        Task<int> Create(ContactViewModel request);

        Task<List<ContactViewModel>> GetAll();
    }
}