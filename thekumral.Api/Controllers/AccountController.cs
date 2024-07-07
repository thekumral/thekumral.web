using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using thekumral.Core.DTOs.Users;
using thekumral.Core.Entities;
using thekumral.Core.Services.Mails;
using Microsoft.AspNetCore.Http;
using thekumral.Api.Controllers.Bases;
using System.Text.Encodings.Web;

namespace thekumral.Api.Controllers
{
    public class AccountController : CustomBaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly IMailService _mailService;

        public AccountController(IMailService mailService, UserManager<User> userManager)
        {
            _mailService = mailService;
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> SignUp(RegisterDto registerDTO)
        {
            var exist = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (exist != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "User already exists" });
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                EmailConfirmed = false,
                UserName = registerDTO.Email,
                CompanyId = registerDTO.CompanyId
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "Registration failed ss" });
            }

            if (!await _userManager.IsInRoleAsync(user, registerDTO.Role.ToString()))
            {
                await _userManager.AddToRoleAsync(user, registerDTO.Role.ToString());
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = new StringBuilder($"https://localhost:7205/api/account/confirmEmail?token={UrlEncoder.Default.Encode(token)}&userId={user.Id}");

            var emailSubject = "Email Confirmation";
            var emailBody = $"Hello , {user.FirstName},<br><br> LastName : {user.LastName} <br><br> Email : {user.Email} <br><br> Password : {registerDTO.Password}<br> <br> Please confirm your email address by clicking the link below:<br><br><a href='{confirmationLink}'>Confirm Email</a> BYY    ";



            var status = _mailService.Send(user.Email, emailSubject, emailBody, true);
            if (status)
            {
                return StatusCode(StatusCodes.Status201Created, new { message = "Confirmation link has been sent to your email address" });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new { message = "Failed to send confirmation email" });
        }
    }
}
