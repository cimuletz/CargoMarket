// <auto-generated />
using System;
using BursaTransport.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BursaTransport.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220121111451_AddedConfigs")]
    partial class AddedConfigs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BursaTransport.DAL.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.ClientTransport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CliendId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Destination")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Source")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientTransports");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.DriverCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverCompanies");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.DriverTransport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Destination")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Source")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("DriverTransports");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DriverId")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxVolume")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("MaxWeight")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("NumberPlate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique()
                        .HasFilter("[DriverId] IS NOT NULL");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.ClientTransport", b =>
                {
                    b.HasOne("BursaTransport.DAL.Entities.Client", "Client")
                        .WithMany("Transports")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.DriverCompany", b =>
                {
                    b.HasOne("BursaTransport.DAL.Entities.Company", "Company")
                        .WithMany("DriverCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BursaTransport.DAL.Entities.Driver", "Driver")
                        .WithMany("DriverCompanies")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.DriverTransport", b =>
                {
                    b.HasOne("BursaTransport.DAL.Entities.Driver", "Driver")
                        .WithMany("Transports")
                        .HasForeignKey("DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Vehicle", b =>
                {
                    b.HasOne("BursaTransport.DAL.Entities.Driver", "Driver")
                        .WithOne("Vehicle")
                        .HasForeignKey("BursaTransport.DAL.Entities.Vehicle", "DriverId");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Client", b =>
                {
                    b.Navigation("Transports");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Company", b =>
                {
                    b.Navigation("DriverCompanies");
                });

            modelBuilder.Entity("BursaTransport.DAL.Entities.Driver", b =>
                {
                    b.Navigation("DriverCompanies");

                    b.Navigation("Transports");

                    b.Navigation("Vehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
