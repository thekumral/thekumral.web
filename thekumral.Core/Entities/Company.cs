using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {

        }
        public Company(string name, string createdBy)
        {
            Name = name;
            CreatedBy = createdBy;
        }
        public string Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
