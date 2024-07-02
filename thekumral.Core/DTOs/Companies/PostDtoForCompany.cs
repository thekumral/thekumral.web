using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.DTOs.Companies
{
    public class PostDtoForCompany : BaseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int ViewCount { get; set; } = 0;
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }



    }
}
