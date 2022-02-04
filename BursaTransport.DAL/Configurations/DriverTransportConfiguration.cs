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
    class DriverTransportConfiguration : IEntityTypeConfiguration<DriverTransport>
    {
        public void Configure(EntityTypeBuilder<DriverTransport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Source).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Destination).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Date).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Price).HasColumnType("decimal(8,2)");
        }
    }
}
