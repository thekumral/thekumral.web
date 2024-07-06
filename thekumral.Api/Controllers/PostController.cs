using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thekumral.Api.Controllers.Bases;
using thekumral.Api.Filters;
using thekumral.Core.DTOs.Companies;
using thekumral.Core.DTOs;
using thekumral.Core.Entities;
using thekumral.Core.Repositories;
using thekumral.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using thekumral.Core.DTOs.Posts;
using System.Security.Claims;
using thekumral.Service.Exceptions;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace thekumral.Api.Controllers
{

    public class PostController : CustomBaseController
    {
        private readonly IPostService _service;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostController(IPostService service, IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(AddPostDto addPostDto)
        {

            var post = _mapper.Map<Post>(addPostDto);
            var currentUserId = _user.FindFirst(ClaimTypes.NameIdentifier).Value;
            post.UserId = Guid.Parse(currentUserId);
            post.CreatedBy = _user.FindFirstValue(ClaimTypes.Email);
            post.CompanyId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "companyid")?.Value);
            var posts = await _service.AddAsync(post);
            
            var postDtos = _mapper.Map<AddPostDto>(posts);
            return CreateActionResult(CustomResponseDto<AddPostDto>.Success(201, postDtos));
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetPostsByCompanyId()
        {
            var CompanyId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "companyid")?.Value);
            return CreateActionResult(await _service.GetPostsByCompanyId(CompanyId));
        }

        //[ServiceFilter(typeof(NotFoundFilter<Post>))]
        [HttpGet("GetPostsByCategoryId/{categoryId}")]
        public IActionResult GetPostsByCategoryId(Guid categoryId)
        {
            return CreateActionResult(_service.GetPostsByCategoryId(categoryId));
        }

        [HttpGet]
        //[Authorize(Roles = "Superadmin")]
        public async Task<IActionResult> All()
        {
            var posts = await _service.GetAllAsync();
            var postsDtos = _mapper.Map<List<PostDto>>(posts.ToList());
            return CreateActionResult(CustomResponseDto<List<PostDto>>.Success(200, postsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Post>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var post = await _service.GetByIdAsync(id);
            if (post.IsDeleted)
                throw new NotFoundException($"No Posts found  post.Id {post.Id}");
            var postDtos = _mapper.Map<PostDto>(post);
            return CreateActionResult(CustomResponseDto<PostDto>.Success(200, postDtos));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(UpdatePostDto updatePostDto)
        {
            var post = await _service.GetByIdAsync(updatePostDto.PostId);

            if (post.IsDeleted)
                throw new NotFoundException($"No Posts found for Post with ID {updatePostDto.PostId}");

            post.CategoryId = updatePostDto.CategoryId;
            post.Title = updatePostDto.Title;
            post.Content = updatePostDto.Content;
            post.ModifiedBy = _user.FindFirstValue(ClaimTypes.Email);
            post.ModifiedDate = DateTime.Now;

            await _service.UpdateAsync(post);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var posts = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(posts);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
