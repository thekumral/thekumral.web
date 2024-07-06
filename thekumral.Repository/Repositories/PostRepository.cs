
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
    /// <summary>
    /// Makale verilerinin veritabanı işlemlerini gerçekleştiren repository sınıfı.
    /// </summary>
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        /// <summary>
        /// PostRepository sınıfının bir örneğini oluşturur.
        /// </summary>
        /// <param name="context">Uygulama veritabanı bağlamı</param>
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Kategori bilgisiyle birlikte tüm makaleleri getirir.
        /// </summary>
        /// <returns>Makalelerin kategori bilgisi ile liste halinde dönüşü <see cref="List{Post}"/></returns>
        public async Task<List<Post>> GetPostsByCompanyId(Guid CompanyId)
        {
            return await _context.Posts.Include(x => x.Category).Where(gp => gp.CompanyId ==CompanyId).ToListAsync();
        }

        /// <summary>
        /// Belirli bir kategori kimliğine sahip makaleleri getirir.
        /// </summary>
        /// <param name="categoryId">Kategori kimliği</param>
        /// <returns>Belirtilen kategoriye ait makalelerin listesi <see cref="List{Post}"/></returns>
        public List<Post> GetPostsByCategoryId(Guid categoryId)
        {
            var posts = _context.Posts
                 .Where(pc => pc.CategoryId == categoryId)
                 .ToList();

            return posts;
        }
        public async Task<List<Post>> GetPostsByCategory()
        {
            var posts = _context.Posts.Include(x=>x.Category).ToListAsync();
            return await posts;
        }

        /// <summary>
        /// Belirli bir şirket kimliğine sahip makaleleri getirir.
        /// </summary>
        /// <param name="companyId">Şirket kimliği</param>
        /// <returns>Belirtilen şirkete ait makalelerin listesi <see cref="List{Post}"/></returns>
        //async Task<List<Post>> IPostRepository.GetPostsByCompanyId(Guid companyId)
        //{
        //    var userPosts = await _context.Users
        //    .Where(u => u.CompanyId == companyId)
        //    .SelectMany(u => u.Posts)
        //    .ToListAsync();

        //    return userPosts;
        //}
    }
}
