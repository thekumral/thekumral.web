using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Categories;

namespace thekumral.Core.DTOs.Posts
{
    public class PostCategoryDto
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }
        //public Post Post { get; set; }
        public CategoryDto Category { get; set; }
    }
}
