
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Repository.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            builder.ToTable("AspNetUserRoles");

            builder.HasData(new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-94D7-0DF96A7F012C"),
                RoleId = Guid.Parse("16EA936C-7A28-4C30-86A2-9A9704B6115E")
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                RoleId = Guid.Parse("7CB750CF-3612-4FB4-9F7D-A38BA8F16BF4")
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0413"),
                RoleId = Guid.Parse("EDF6C246-41D8-475F-8D92-41DDDAC3AEFB")
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0111"),
                RoleId = Guid.Parse("EDF6C246-41D8-475F-8D92-41DDDAC5AEFB")
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0431"),
                RoleId = Guid.Parse("16EA936C-7A28-4C30-86A2-9A9704B6115E")
            },
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0222"),
                RoleId = Guid.Parse("7CB750CF-3612-4FB4-9F7D-A38BA8F16BF4")
            });
        }
    }
}
