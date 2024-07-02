using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Entities;

namespace thekumral.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithPostAsync(Guid categoryId);
        Task<List<Post>> GetPostsByCategoryIdAsync(Guid categoryId);


    }
}
