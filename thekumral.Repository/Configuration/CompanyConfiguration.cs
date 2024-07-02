
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
    /// <summary>
    /// Şirket varlıklarının veritabanı tablosu yapılandırmasını sağlayan sınıf.
    /// </summary>
    internal class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        /// <summary>
        /// Şirket varlıklarının veritabanı tablosu yapılandırmasını gerçekleştirir.
        /// </summary>
        /// <param name="builder">Entity tipi için yapılandırıcı</param>
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany<User>().WithOne().HasForeignKey(ut => ut.CompanyId).IsRequired();

            builder.HasData(new Company()
            {
                Id = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C"),
                Name = "ApaDesign",
                CreatedBy = "Super Admin"
            },
            new Company()
            {
                Id = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F044C"),
                Name = "Kumrals",
                CreatedBy = "Super Admin"
            },
            new Company()
            {
                Id = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F032C"),
                Name = "CodeLikeARose",
                CreatedBy = "Super Admin"
            });
        }

       
    }
}
