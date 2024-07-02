using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set;}
        public virtual DateTime? DeletedDate { get; set; }
        public virtual string CreatedBy { get; set; } = "Undifinied";
        public virtual string? ModifiedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
