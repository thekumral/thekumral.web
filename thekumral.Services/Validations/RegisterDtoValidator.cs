using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using thekumral.Core.DTOs.Users;
using thekumral.Core.Entities;

namespace thekumral.Service.Validations
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("İsim Soyisim");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("İsim Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(60)
                .EmailAddress()
                .MinimumLength(8)
                .WithName("E-posta Adresi");

            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Parola Tekrarı");

            //RuleFor(x => x.Role)
            //    .IsInEnum()
            //    .WithName("Rol")
            //    .Must(role => role == RoleType.CompanyAdmin || role == RoleType.CompanyAuthor)
            //    .WithMessage("Rol tipi 0 (Companyadmin) veya 1 (Companyauthor) olmalıdır.");

            RuleFor(x => x.CompanyId).NotNull().NotEmpty().WithName("Sirket Id");
        }
    }
}
