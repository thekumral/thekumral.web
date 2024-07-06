
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
    /// Kategori varlığının veritabanı yapılandırmasını yapılandırır.
    /// </summary>
    /// <param name="builder">Varlık yapılandırma yapılandırıcısı</param>
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category()
            {
                Id = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B"),
                Name = "C# Nedir ?",
                CreatedBy = "Deneme",
                CompanyId= Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C"),
                UserId= Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                IsDeleted= false,
            },
            new Category()
            {
                Id = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1"),
                Name = "Visual Studio - Vs Code Çatışması",
                CreatedBy = "Deneme",
                CompanyId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F061C"),
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                IsDeleted = false,
            });
        }
    }
}
