using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using thekumral.Api.Controllers.Bases;
using thekumral.Api.Filters;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Companies;
using thekumral.Core.DTOs.Users;
using thekumral.Core.Entities;
using thekumral.Core.Services;

namespace thekumral.Api.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _authService.Login(loginDto);
            return CreateActionResult(response);
        }
    }
}
