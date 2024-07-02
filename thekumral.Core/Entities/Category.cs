using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace thekumral.Core.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
        }
        public Category(string name, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
        }
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }
    }
}
