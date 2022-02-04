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
    class VehicleConfiguration :IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumberPlate).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.MaxWeight).HasColumnType("decimal(5,2)");
            builder.Property(x => x.MaxVolume).HasColumnType("decimal(5,2)");
        }
    }
}
