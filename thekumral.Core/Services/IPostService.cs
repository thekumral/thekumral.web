using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Posts;

namespace thekumral.Core.Services
{
    internal interface IPostService
    {
        Task<CustomResponseDto<List<PostWithCategoryDto>>> GetPostsWithCategory(Guid CompanyId);
        CustomResponseDto<List<PostWithCategoryDto>> GetPostsByCategoryId(Guid categoryId);
    }
}
