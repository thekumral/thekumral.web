using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Entities;

namespace thekumral.Core.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<List<Company>> GetPostWithUsersCompany();
        Task<List<Post>> GetPostsByCompanyIdAsync(Guid companyId);

    }
}
