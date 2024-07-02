
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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = Guid.Parse("16EA936C-7A28-4C30-86A2-9A9704B6115E"),
                Name = "Superadmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Id = Guid.Parse("7CB750CF-3612-4FB4-9F7D-A38BA8F16BF4"),
                Name = "Companyadmin",
                NormalizedName = "COMPANYADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Id = Guid.Parse("EDF6C246-41D8-475F-8D92-41DDDAC3AEFB"),
                Name = "Companyauthor",
                NormalizedName = "COMPANYAUTHOR",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new Role
            {
                Id = Guid.Parse("EDF6C246-41D8-475F-8D92-41DDDAC5AEFB"),
                Name = "DefaultUser",
                NormalizedName = "DEFAULTUSER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
