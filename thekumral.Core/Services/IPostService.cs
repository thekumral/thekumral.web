using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.Entities;

namespace thekumral.Core.Services
{
    public interface IPostService:IService<Post>
    {
        Task<CustomResponseDto<List<PostDto>>> GetPostsByCompanyId(Guid CompanyId);
        CustomResponseDto<List<PostDto>> GetPostsByCategoryId(Guid categoryId);
        Task<CustomResponseDto<PostDto>> GetPostsByCategory();
    }
}
