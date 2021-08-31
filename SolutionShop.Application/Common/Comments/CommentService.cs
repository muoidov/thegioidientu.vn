using SolutionShop.Data.EF;
using SolutionShop.Data.Entities;
using SolutionShop.ViewModel.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolutionShop.Application.Common.Comments
{
    public class CommentService : ICommentService
    {
        private readonly Shopdbcontext _context;

        public CommentService(Shopdbcontext context)
        {
            _context = context;
        }

        public async Task<int> Create(CommentViewModel request)
        {
            var comment = new Comment()
            {
                Name = request.Name,
                ProductId = request.ProductId,
                Contents = request.Content
            };
            _context.Comments.Add(comment);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<CommentViewModel>> GetByProduct(int productId)
        {
            var query = _context.Comments.Where(x => x.ProductId == productId);

            List<CommentViewModel> rs = new List<CommentViewModel>();
            foreach (var item in query)
            {
                CommentViewModel model = new CommentViewModel()
                {
                    Name = item.Name,
                    Content = item.Contents
                };
                rs.Add(model);
            }
            return rs;
        }
    }
}