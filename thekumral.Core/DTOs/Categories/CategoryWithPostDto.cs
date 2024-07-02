using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Posts;

namespace thekumral.Core.DTOs.Categories
{
    public class CategoryWithPostDto : CategoryDto
    {
        public List<PostDto> Posts { get; set; }
    }
}
