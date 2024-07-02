using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Categories;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.DTOs;
using thekumral.Core.Entities;

namespace thekumral.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        /// <summary>
        /// Kategori ID'ye göre tek makale döndüren fonksiyon
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns type=>Makalelerin kategori bilgisi ile gelen özel yanıt <see cref="CategoryWithPostDto"/></returns>
        public Task<CustomResponseDto<CategoryWithPostDto>> GetSingleCategoryByIdWithPostAsync(Guid categoryId);


        /// <summary>
        /// Kategori ID'ye göre makaleleri liste olarak döndüren asenkron fonksiyon.
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns> Kategori id 'ye göre <see cref="List{PostDto}"/>. </returns>
        public Task<List<PostDto>> GetPostsByCategoryIdAsync(Guid categoryId);
    }
}
