using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Users;

namespace thekumral.Core.DTOs.Posts
{
    public class PostDto : BaseDto
    {
        //public Guid Id { get; set; }
        //public string Header { get; set; }
        // public string PermaLink { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        //public bool Visible { get; set; }
        //public DateTimeOffset? UpdateDate { get; set; }
        //public int? Visits { get; set; }
        public int ViewCount { get; set; } = 0;
        public string Url { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }


        public List<PostCategoryDto> Categories { get; set; }


        //public List<PostEntryFileDto> PostEntryFiles { get; set; }
        //public List<PostTagDto> Tags { get; set; }
        //public List<PostMetaDto> PostMetas { get; set; }

        //public PostDto()
        //{
        //    //PostEntryFiles = new List<PostEntryFileDto>();
        //    //Tags = new List<PostTagDto>();
        //    Categories = new List<PostCategoryDto>();
        //    //PostMetas = new List<PostMetaDto>();
        //}
    }
}
