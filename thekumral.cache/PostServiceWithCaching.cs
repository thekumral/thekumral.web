using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.Entities;
using thekumral.Core.Repositories;
using thekumral.Core.Services;
using thekumral.Core.UnitOfWork;
using thekumral.Service.Exceptions;

namespace thekumral.Caching
{
    public class PostServiceWithCaching : IPostService
    {
        private readonly string CachePostKey = "PostsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IPostRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PostServiceWithCaching(
            IMapper mapper,
            IMemoryCache memoryCache,
            IPostRepository repository,
            IUnitOfWork unitOfWork
        )
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;
            // Önbelleğe alınmış makaleler varsa, bunları önbellekten alır.
            if (!_memoryCache.TryGetValue(CachePostKey, out _))
            {
                CacheAllPostAsync().Wait();
            }
        }

        public async Task<Post> AddAsync(Post entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPostAsync();
            return entity;
        }

        public async Task<IEnumerable<Post>> AddRangeAsync(IEnumerable<Post> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllPostAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Post, bool>> expression)
        {
            var posts = _memoryCache.Get<IEnumerable<Post>>(CachePostKey);
            return Task.FromResult(posts.Any(expression.Compile()));
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            var posts = _memoryCache.Get<IEnumerable<Post>>(CachePostKey);
            return Task.FromResult(posts);
        }

        public CustomResponseDto<List<PostDto>> GetPostsByCategoryId(Guid categoryId)
        {
            var posts = _memoryCache.Get<IEnumerable<Post>>(CachePostKey);
            var filteredPosts =  posts.Where(x => x.CategoryId == categoryId).ToList();
            if (!filteredPosts.Any())
            {
                var postsNoCache = _repository.GetPostsByCategoryId(categoryId);
                var FilteredPostsNoCache = postsNoCache.Where(x => x.CategoryId == categoryId).ToList();
                if (FilteredPostsNoCache.Any())
                {
                    throw new NotFoundException($"No Posts found for category with ID {categoryId}");
                }
            }
            var postWithCategoryDto = _mapper.Map<List<PostDto>>(filteredPosts);
            return CustomResponseDto<List<PostDto>>.Success(200, postWithCategoryDto);
        }

        public async Task<CustomResponseDto<List<PostDto>>> GetPostsByCompanyId(Guid companyId)
        {
            var posts = await _repository.GetPostsByCompanyId(companyId);
            if (!posts.Any())
            {
                throw new NotFoundException($"No Posts found for company with ID {companyId}");
            }
            var postWithCompanyDto = _mapper.Map<List<PostDto>>(posts);
            return CustomResponseDto<List<PostDto>>.Success(200, postWithCompanyDto);
        }

        public Task<CustomResponseDto<List<PostDto>>> GetPostsWithCategory()
        {
            var posts = _memoryCache.Get<IEnumerable<Post>>(CachePostKey);
            var postWithCategoryDto = _mapper.Map<List<PostDto>>(posts);
            return Task.FromResult(
                CustomResponseDto<List<PostDto>>.Success(200, postWithCategoryDto)
            );
        }

        public async Task<CustomResponseDto<List<PostDto>>> GetPostsWithCompanyId(Guid companyId)
        {
            var posts = await _repository.GetPostsByCompanyId(companyId);
            if (!posts.Any())
            {
                throw new NotFoundException($"No Posts found for company with ID {companyId}");
            }
            var postWithCategoryDto = _mapper.Map<List<PostDto>>(posts);
            return CustomResponseDto<List<PostDto>>.Success(200, postWithCategoryDto);
        }

        public Task<Post> GetByIdAsync(Guid id)
        {
            var post = _memoryCache.Get<List<Post>>(CachePostKey).FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                throw new NotFoundException($"Post with ID {id} not found");
            }
            return Task.FromResult(post);
        }

        public async Task RemoveAsync(Post entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPostAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Post> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllPostAsync();
        }

        public async Task UpdateAsync(Post entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllPostAsync();
        }

        public IQueryable<Post> Where(Expression<Func<Post, bool>> expression)
        {
            return _memoryCache
                .Get<List<Post>>(CachePostKey)
                .Where(expression.Compile())
                .AsQueryable();
        }

        public async Task CacheAllPostAsync()
        {
            var allPosts = await _repository.GetAll().ToListAsync();
            _memoryCache.Set(CachePostKey, allPosts);
        }

        public Task<CustomResponseDto<PostDto>> GetPostsByCategory()
        {
            var posts = _memoryCache.Get<IEnumerable<Post>>(CachePostKey);
            var GetPostsByCategoryDto = _mapper.Map<PostDto>(posts);
            return Task.FromResult(
                CustomResponseDto<PostDto>.Success(200, GetPostsByCategoryDto)
            );
        }

    }
}
