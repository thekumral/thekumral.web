using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.DTOs.Categories
{
    public class CategoryDto : BaseDto
    {
        //public Guid ParentId { get; set; }
        public string Name { get; set; }
        //public int Priorty { get; set; }
        public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }
        //public string DeletedBy { get; set; }
        public Boolean IsDeleted { get; set; } = false;


    }
}
