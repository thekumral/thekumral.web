using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Categories;
using thekumral.Core.DTOs.Companies;
using thekumral.Core.DTOs.Posts;
using thekumral.Core.DTOs.Users;
using thekumral.Core.Entities;

namespace thekumral.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();

            //Blog ve BlogDto arasında çift yönlü eşleme yapar
            //CreateMap<Blog, BlogDto>().ReverseMap();

            // User ve UserDto arasında çift yönlü eşleme yapar
            CreateMap<User, UserDto>().ReverseMap();

            // Category ve CategoryDto arasında çift yönlü eşleme yapar
            CreateMap<Category, CategoryDto>().ReverseMap();

            // Company ve CompanyDto arasında çift yönlü eşleme yapar
            CreateMap<Company, CompanyDto>().ReverseMap();

            //// Post ve PostWithCategoryDto arasında tek yönlü eşleme yapar
            //CreateMap<Post, PostWithCategoryDto>();// Gidecek
            //// Post ve PostWithCompanyDto arasında tek yönlü eşleme yapar
            //CreateMap<Post, PostWithCompanyDto>();// Gidecek
            ///To Do Düzelt şunları gereksizleri !

            CreateMap<User, RegisterDto>().ReverseMap();

            CreateMap<Post, AddPostDto>().ReverseMap();
            CreateMap<Post, UpdatePostDto>().ReverseMap();


            //CreateMap<Company, CompanyWithUserDto>().ReverseMap();// Gidecek
            CreateMap<Company, AddCompanyDto>().ReverseMap();
            //CreateMap<Post, CompanyWithUserDto>().ReverseMap(); // Gidecek
            CreateMap<Post, PostDtoForCompany>().ReverseMap();
        }
    }
}
