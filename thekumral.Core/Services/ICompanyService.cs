using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Companies;
using thekumral.Core.DTOs;
using thekumral.Core.Entities;

namespace thekumral.Core.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<CustomResponseDto<List<CompanyWithUserDto>>> GetPostCompanyWithUsers();
        Task<CustomResponseDto<List<PostDtoForCompany>>> GetPostsByCompanyIdAsync(Guid companyId);

    }
}
