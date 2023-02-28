﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property.DatabaseEntity;

#nullable disable

namespace Property.DatabaseEntity.Migrations
{
    [DbContext(typeof(PropertyContext))]
    [Migration("20230311161343_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PropertyAccount.Domain.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateToMove")
                        .HasColumnType("datetime2");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsReadyToMove")
                        .HasColumnType("bit");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.ContractorAndBuilder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgreementNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyRegistrationNumber")
                        .HasColumnType("int");

                    b.Property<string>("ContractorBuilderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfContract")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSubcontractor")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfHouseAllocated")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("ContractorAndBuilders");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Council")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dateofbuilt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConstructed")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfGarages")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfFloors")
                        .HasColumnType("int");

                    b.Property<string>("PropertyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rooms")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDomesticUse")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFreeHold")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfRegistrant")
                        .HasColumnType("int");

                    b.Property<int>("NoOfYearLease")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistrationPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistterdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.Address", b =>
                {
                    b.HasOne("PropertyAccount.Domain.Model.Property", "Property")
                        .WithMany("Addresses")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.ContractorAndBuilder", b =>
                {
                    b.HasOne("PropertyAccount.Domain.Model.Property", "Property")
                        .WithMany("ContractorAndBuilders")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.Registration", b =>
                {
                    b.HasOne("PropertyAccount.Domain.Model.Address", "Address")
                        .WithMany("Registrations")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.Address", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("PropertyAccount.Domain.Model.Property", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ContractorAndBuilders");
                });
#pragma warning restore 612, 618
        }
    }
}
