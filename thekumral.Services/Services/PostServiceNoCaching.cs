using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.DTOs;
using thekumral.Core.Entities;
using thekumral.Core.Repositories;
using thekumral.Core.UnitOfWork;
using thekumral.Core.Services;

namespace thekumral.Service.Services
{
    public class PostServiceWithNoCaching : Service<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// PostServiceWithNoCaching sınıfının bir örneğini oluşturur.
        /// </summary>
        /// <param name="repository">GenericRepository örneği</param>
        /// <param name="unitOfWork">UnitOfWork örneği</param>
        /// <param name="mapper">AutoMapper örneği</param>
        /// <param name="postRepository">Makale repository örneği</param>
        public PostServiceWithNoCaching(IGenericRepository<Post> repository, IUnitOfWork unitOfWork, IMapper mapper, IPostRepository postRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        /// <summary>
        /// Kategorilerle birlikte makaleleri getiren işlem.
        /// </summary>
        /// <returns>Makalelerin kategori bilgisiyle özel yanıtı <see cref="List{PostWithCategoryDto}"/> </returns>
        public async Task<CustomResponseDto<List<PostDto>>> GetPostsWithCompanyId(Guid CompanyId)
        {
            var posts = await _postRepository.GetPostsByCompanyId(CompanyId);
            var postsDto = _mapper.Map<List<PostDto>>(posts);
            return CustomResponseDto<List<PostDto>>.Success(200, postsDto);
        }


        /// <summary>
        /// Belirli bir kategoriye ait makaleleri getiren işlem.
        /// </summary>
        /// <param name="categoryId">Kategori kimliği</param>
        /// <returns>Makalelerin kategori bilgisiyle özel yanıtı <see cref="List{PostWithCategoryDto}"/></returns>
        public CustomResponseDto<List<PostDto>> GetPostsByCategoryId(Guid categoryId)
        {
            var posts = _postRepository.GetPostsByCategoryId(categoryId);
            var postsDto = _mapper.Map<List<PostDto>>(posts);
            return CustomResponseDto<List<PostDto>>.Success(200, postsDto);
        }

        /// <summary>
        /// Belirli bir şirkete ait makaleleri getiren işlem.
        /// </summary>
        /// <param name="companyId">Şirket kimliği</param>
        /// <returns>Makalelerin şirket bilgisiyle özel yanıtı <see cref="List{PostWithCompanyDto}"/></returns>
        public async Task<CustomResponseDto<List<PostDto>>> GetPostsByCompanyId(Guid companyId)
        {
            var posts = await _postRepository.GetPostsByCompanyId(companyId);
            var postsDto = _mapper.Map<List<PostDto>>(posts);
            return CustomResponseDto<List<PostDto>>.Success(200, postsDto);
        }

        public async Task<CustomResponseDto<PostDto>> GetPostsByCategory()
        {
            var posts = await _postRepository.GetPostsByCategory();
            var postDto = _mapper.Map<PostDto>(posts);
            return CustomResponseDto<PostDto>.Success(200,postDto);
        }
    }
}
