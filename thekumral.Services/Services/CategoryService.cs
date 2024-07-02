using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Categories;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.Entities;
using thekumral.Core.Services;

namespace thekumral.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public Task<Category> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> AddRangeAsync(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Category, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostDto>> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<CategoryWithPostDto>> GetSingleCategoryByIdWithPostAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> Where(Expression<Func<Category, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
