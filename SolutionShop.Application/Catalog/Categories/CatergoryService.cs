using SolutionShop.Data.EF;
using SolutionShop.ViewModel.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolutionShop.ViewModel.Common;
using SolutionShop.Utilities.Exceptions;
using SolutionShop.Data.Entities;

namespace SolutionShop.Application.Catalog.Categories
{
    public class CatergoryService : ICatergoryService
    {
        private readonly Shopdbcontext _context;

        public CatergoryService(Shopdbcontext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(CategoryAllModel request)
        {
            var languages = _context.Languages.OrderByDescending(x => x.Id);
            var translation = new List<CategoryTranslation>();
            foreach (var language in languages)
            {
                translation.Add(new CategoryTranslation()
                {
                    Name = request.Name,
                    LanguageId = language.Id,
                    SeoAlias = request.SeoAlias,
                    SeoDescription = request.SeoDescription,
                    SeoTitle = request.SeoTitle,
                });
            }

            var category = new Category()
            {
                IsShowHome = true,
                ParenId = request.ParenId,
                SortOrder = 1,
                Status = 1,
                CategoryTranslations = translation
            };
            _context.Categories.Add(category);
            var rs = await _context.SaveChangesAsync();
            if (rs != 0)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiError<bool>();
        }

        public async Task<int> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new Shopexception($"Không thể tìm thấy:{id}");
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParenId
            }).ToListAsync();
        }

        public async Task<PagedResult<CategoryAllModel>> GetAllPaging(CatergoryPagingRequest request)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId into ctt
                        from ct in ctt.DefaultIfEmpty()
                        where ct.LanguageId == request.LanguageId
                        select new { c, ct };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).
                Select(x => new CategoryAllModel()
                {
                    Id = x.c.Id,
                    IsShowHome = x.c.IsShowHome,
                    ParenId = x.c.ParenId,
                    Name = x.ct.Name,
                    LanguageId = x.ct.LanguageId
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryAllModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParenId
            }).FirstOrDefaultAsync();
        }

        public async Task<List<CategoryParent>> GetParentId()
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId into ctt
                        from ct in ctt.DefaultIfEmpty()
                        where c.ParenId == null && ct.LanguageId == "vi-VN"
                        select new { c, ct };

            return await query.Select(x => new CategoryParent()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                Selected = false
            }).ToListAsync(); ;
        }
    }
}