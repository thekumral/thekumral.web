using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Categories;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.Entities;
using thekumral.Core.Repositories;
using thekumral.Core.Services;
using thekumral.Core.UnitOfWork;

namespace thekumral.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryService categoryService, IMapper mapper,IGenericRepository<Category> repository,IUnitOfWork unitOfWork) : base(repository,unitOfWork)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            var posts = await _categoryService.GetPostsByCategoryIdAsync(categoryId);
            var postDto = _mapper.Map<List<PostDto>>(posts);
            return postDto;
        }
        
        public async Task<CustomResponseDto<PostDto>> SingleCategoryPostsByCategoryId(Guid categoryId)
        {
            var category = await _categoryService.SingleCategoryPostsByCategoryId(categoryId);
            var postDto = _mapper.Map<PostDto>(category);
            return CustomResponseDto<PostDto>.Success(200,postDto);
        }

    }
}
