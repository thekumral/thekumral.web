
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// CategoryRepository sınıfının bir örneğini oluşturur.
        /// </summary>
        /// <param name="context">Uygulama veritabanı bağlamı</param>
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Belirli bir kategori kimliğine sahip kategoriyi ve bu kategoriye ait makaleleri getiren işlev.
        /// </summary>
        /// <param name="categoryId">Kategori kimliği</param>
        /// <returns>Kategori ve bu kategoriye ait makalelerin özel yanıtı <see cref="Post"/></returns>
        public async Task<Category> GetSingleCategoryByIdWithPostAsync(Guid categoryId)
        {
            var categoryWithPosts = await _context.Categories
            .Include(c => c.Posts)
            .FirstOrDefaultAsync(c => c.Id == categoryId);
            return categoryWithPosts;
        }

        /// <summary>
        /// Belirli bir kategori kimliğine sahip makaleleri getiren işlev.
        /// </summary>
        /// <param name="categoryId">Kategori kimliği</param>
        /// <returns>Kategoriye ait makalelerin listesi  <see cref="Post"/></returns>
        public async Task<List<Post>> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            var posts = await _context.Posts
             .Where(pc => pc.CategoryId == categoryId)
             .ToListAsync();
            return posts;
        }


    }

}
