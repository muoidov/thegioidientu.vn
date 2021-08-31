using SolutionShop.ViewModel.Common;
using SolutionShop.ViewModel.System.Contact;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegration
{
    public interface IContactApiClient
    {
        Task<List<ContactViewModel>> GetAll();

        Task<bool> Create(ContactViewModel request);
    }
}