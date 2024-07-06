using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Entities;

namespace thekumral.Core.DTOs.Categories
{
    public class CategoryDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }


    }
}
