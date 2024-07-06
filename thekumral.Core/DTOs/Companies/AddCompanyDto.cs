using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.DTOs.Companies
{
    public class AddCompanyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual string CreatedBy { get; set; } = "Undefined";
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;

    }
}
