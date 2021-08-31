using SolutionShop.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SolutionShop.Application.Common.Comments
{
    public interface ICommentService
    {
        Task<int> Create(CommentViewModel request);

        Task<List<CommentViewModel>> GetByProduct(int productId);
    }
}