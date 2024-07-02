using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using thekumral.Core.DTOs.Users;
using thekumral.Core.Entities;
using thekumral.Core.Services;
using thekumral.Core.Services.Tokens;

namespace thekumral.Service.Services
{
    public class AuthService : IAuthService
    {
        public readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public AuthService(
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ITokenService tokenService,
            IConfiguration configuration
        )
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            var result = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (user == null || !result)
            {
                return new LoginResponseDto();
            }
            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

            _ = int.TryParse(
                configuration["JWT:RefreshTokenValidityInDays"],
                out int refreshTokenValidityInDays
            );

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);
            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }

        public async Task<IdentityResult> RegisterUser(RegisterDto registerDto) 
        {
            User user = mapper.Map<User>(registerDto);
            user.UserName = registerDto.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerDto.Role.ToString());
            }

            return result;


        }
    }
}
