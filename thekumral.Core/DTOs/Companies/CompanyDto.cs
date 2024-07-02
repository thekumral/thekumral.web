using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Users;

namespace thekumral.Core.DTOs.Companies
{
    public class CompanyDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }

        public CompanyDto()
        {
            Users = new List<UserDto>();
        }
    }
}
