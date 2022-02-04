using BursaTransport.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BursaTransport.DAL.Configurations
{
    class DriverCompanyConfiguration : IEntityTypeConfiguration<DriverCompany>
    {
        public void Configure(EntityTypeBuilder<DriverCompany> builder)
        {
            builder.HasOne(p => p.Driver)
                   .WithMany(p => p.DriverCompanies)
                   .HasForeignKey(p => p.DriverId);

            builder.HasOne(p => p.Company)
                .WithMany(p => p.DriverCompanies)
                .HasForeignKey(p => p.CompanyId);

        }
    }
}
