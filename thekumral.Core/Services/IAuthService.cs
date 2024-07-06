using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Users;

namespace thekumral.Core.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterUser(RegisterDto registerDto);

        Task<CustomResponseDto<LoginResponseDto>> Login(LoginDto loginDto);
    }
}
