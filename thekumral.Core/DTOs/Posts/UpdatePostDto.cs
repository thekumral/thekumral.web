using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.DTOs.Posts
{
    public class UpdatePostDto
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public string ShortContent { get; set; }
        public string Url { get; set; }
       // public  DateTime ModifiedDate => DateTime.Now;
    }
}
