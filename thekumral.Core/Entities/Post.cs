using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.Entities
{
    public class Post:BaseEntity
    {
        public Post()
        {
            
        }
        public Post(string title,string content, string createdBy,Guid userId, Guid categoryId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;
        public Guid? CompanyId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public Category? Category{ get; set; }
        public User? User{ get; set; }
        
    }
}
