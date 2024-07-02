
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.Entities;

namespace thekumral.Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var superadminForApa = new User()
            {
                Id = Guid.Parse("CB94223B-CCB8-4F2F-94D7-0DF96A7F012C"),
                UserName = "SuperAdminApa",
                NormalizedUserName = "SUPERADMINAPA",
                Email = "info@apadesign.net",
                NormalizedEmail = "INFO@APADESIGN.NET",
                PhoneNumber = "+905439999999",
                FirstName = "SuperMahmut",
                LastName = "KUMRAL",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C")
            };
            superadminForApa.PasswordHash = CreatePasswordHash(superadminForApa, "1");

            var companyAdminForApa = new User()
            {
                Id = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                UserName = "CompanyAdminForApa",
                NormalizedUserName = "COMPANYADMINFORAPA",
                Email = "mahmutkumral@apadesign.net",
                NormalizedEmail = "MAHMUTKUMRAL@APADESIGN.NET",
                PhoneNumber = "+905363282325",
                FirstName = "Mahmut",
                LastName = "KUMRAL",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C")
            };
            companyAdminForApa.PasswordHash = CreatePasswordHash(companyAdminForApa, "1");

            var companyAuthorForApa = new User()
            {
                Id = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0413"),
                UserName = "companyAuthorForApa",
                NormalizedUserName = "COMPANYAUTHORFORAPA",
                Email = "Mustafa@apadesign.net",
                NormalizedEmail = "MUSTAFA@APADESIGN.NET",
                PhoneNumber = "+905302238522",
                FirstName = "Mustafa",
                LastName = "KUMRAL",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C")
            };
            companyAuthorForApa.PasswordHash = CreatePasswordHash(companyAuthorForApa, "1");

            var DefaultUserForApa = new User()
            {
                Id = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0111"),
                UserName = "defaultUser",
                NormalizedUserName = "DEFAULTUSER",
                Email = "default@apadesign.net",
                NormalizedEmail = "DEFAULT@APADESIGN.NET",
                PhoneNumber = "",
                FirstName = "Default",
                LastName = "USER",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C")
            };
            DefaultUserForApa.PasswordHash = CreatePasswordHash(DefaultUserForApa, "1");
            
            var superadminForKumral = new User()
            {
                Id = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0431"),
                UserName = "thekumral",
                NormalizedUserName = "THEKUMRAL",
                Email = "thekumral@kumral.com",
                NormalizedEmail = "THEKUMRAL@KUMRAL.COM",
                PhoneNumber = "+905494000602",
                FirstName = "Ömer Faruk",
                LastName = "KUMRAL",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F044C")
            };
            superadminForKumral.PasswordHash = CreatePasswordHash(superadminForKumral, "1");


            var companyAdminForKumral= new User()
            {
                Id = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0222"),
                UserName = "",
                NormalizedUserName = "",
                Email = "omer@kumral.com",
                NormalizedEmail = "OMER@KUMRAL.COM",
                PhoneNumber = "+905494000602",
                FirstName = "Ömer Faruk",
                LastName = "KUMRAL",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F044C")
            };
            companyAdminForKumral.PasswordHash = CreatePasswordHash(companyAdminForKumral, "1");
            builder.HasData(companyAdminForKumral, superadminForKumral, DefaultUserForApa, companyAdminForApa, superadminForApa, companyAuthorForApa);
        }

        private string CreatePasswordHash(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
