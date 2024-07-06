using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Entities;

namespace thekumral.Core.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<List<Post>> GetPostsByCompanyId(Guid CompanyId);
        List<Post> GetPostsByCategoryId(Guid categoryId);
        Task<List<Post>> GetPostsByCategory();
    }
}
