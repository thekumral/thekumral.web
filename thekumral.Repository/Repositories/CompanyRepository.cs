
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Entities;
using thekumral.Core.Repositories;

namespace thekumral.Repository.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetPostCompanyWithUsers()
        {
            var Company = _context.Companies.Include(x => x.Users).ToListAsync();
            return await Company;
        }

        public async Task<List<Post>> GetPostsByCompanyIdAsync(Guid companyId)
        {
            var postsWithCompany = await _context.Posts
                .Include(p => p.User) // User ilişkisini dahil edin
                .Where(p => p.User.CompanyId == companyId) // Şirket ID'sine göre filtreleyin
                .ToListAsync();

            return postsWithCompany;
        }

    }
}
