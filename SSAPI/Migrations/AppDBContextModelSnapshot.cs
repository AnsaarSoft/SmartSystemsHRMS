﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSAPI.Context;

#nullable disable

namespace SSAPI.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.26");

            modelBuilder.Entity("SharedLibrary.Model.EmployeeManagement.MstEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ConfirmationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeCountry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomeEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MotherName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ServiceEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ServiceStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WorkAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkCity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkCountry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkPhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("cAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("flgActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("flgDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("uAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MstEmployee");
                });

            modelBuilder.Entity("SharedLibrary.Model.EmployeeManagement.MstUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UnitId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<ushort>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("cAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("flgActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("flgDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("uAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("UnitId");

                    b.ToTable("MstUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a715f91f-ac4c-46c5-bd27-2689ad1fbb56"),
                            CreatedBy = "Auto",
                            CreatedDate = new DateTime(2024, 2, 21, 10, 54, 13, 330, DateTimeKind.Local).AddTicks(7724),
                            Email = "",
                            Password = "super@123",
                            UpdatedBy = "Auto",
                            UpdatedDate = new DateTime(2024, 2, 21, 10, 54, 13, 330, DateTimeKind.Local).AddTicks(7732),
                            UserCode = "manager",
                            UserType = (ushort)1,
                            cAppStamp = "Auto",
                            flgActive = true,
                            flgDelete = false,
                            uAppStamp = "Auto"
                        });
                });

            modelBuilder.Entity("SharedLibrary.Model.OrganizationManagement.MstCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Subscription")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("cAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("flgActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("flgDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("uAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MstCompany");
                });

            modelBuilder.Entity("SharedLibrary.Model.OrganizationManagement.MstUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("cAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<bool>("flgActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("flgDelete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("uAppStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("MstUnit");
                });

            modelBuilder.Entity("SharedLibrary.Model.EmployeeManagement.MstUser", b =>
                {
                    b.HasOne("SharedLibrary.Model.OrganizationManagement.MstCompany", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("SharedLibrary.Model.EmployeeManagement.MstEmployee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SharedLibrary.Model.OrganizationManagement.MstUnit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Company");

                    b.Navigation("Employee");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("SharedLibrary.Model.OrganizationManagement.MstUnit", b =>
                {
                    b.HasOne("SharedLibrary.Model.OrganizationManagement.MstCompany", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
