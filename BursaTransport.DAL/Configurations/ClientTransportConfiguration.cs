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
    class ClientTransportConfiguration : IEntityTypeConfiguration<ClientTransport>
    {
        public void Configure(EntityTypeBuilder<ClientTransport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Source).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Destination).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Weight).HasColumnType("decimal(5,2)");
            builder.Property(x => x.Volume).HasColumnType("decimal(5,2)");
            builder.Property(x => x.Price).HasColumnType("decimal(8,2)");
            builder.Property(x => x.Date).HasColumnType("nvarchar(100)").HasMaxLength(100);
        }
    }
}
