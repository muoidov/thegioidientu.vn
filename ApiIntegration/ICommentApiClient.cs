using SolutionShop.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegration
{
    public interface ICommentApiClient
    {
        Task<List<CommentViewModel>> GetByProduct(int productId);

        Task<bool> Create(CommentViewModel request);
    }
}