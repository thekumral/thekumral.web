using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Categories;
using thekumral.Core.DTOs.Users;

namespace thekumral.Core.DTOs.Posts
{
    public class PostDto : BaseDto
    {

        public string Title { get; set; }
        public string? ShortContent { get; set; }
        public string Content { get; set; }
        public string? CreatedBy { get; set; }
        public int ViewCount { get; set; } = 0;
        public string? Url { get; set; }
        public Guid CompanyId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public UserDto? User { get; set; }
        public List<CategoryDto>? Categories { get; set; }
    }
}
