﻿// <auto-generated />
using System;
using IMS.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Source.Migrations
{
    [DbContext(typeof(InterviewManagementSystemDbContext))]
    partial class IMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IMS.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("IMS.Models.Drive", b =>
                {
                    b.Property<int>("DriveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriveId"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CancelReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsScheduled")
                        .HasColumnType("bit");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("ModeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("PoolId")
                        .HasColumnType("int");

                    b.Property<double>("SlotTiming")
                        .HasColumnType("float");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("DriveId");

                    b.HasIndex("AddedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Drives");
                });

            modelBuilder.Entity("IMS.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("IMS.Models.EmployeeAvailability", b =>
                {
                    b.Property<int>("EmployeeAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeAvailabilityId"), 1L, 1);

                    b.Property<string>("CancellationReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriveId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInterviewCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInterviewScheduled")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeAvailabilityId");

                    b.HasIndex("DriveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeAvailability");
                });

            modelBuilder.Entity("IMS.Models.EmployeeDriveResponse", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseId"), 1L, 1);

                    b.Property<int>("DriveId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ResponseType")
                        .HasColumnType("int");

                    b.HasKey("ResponseId");

                    b.HasIndex("DriveId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeDriveResponse");
                });

            modelBuilder.Entity("IMS.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("IMS.Models.Pool", b =>
                {
                    b.Property<int>("PoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoolId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PoolName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PoolId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Pools");
                });

            modelBuilder.Entity("IMS.Models.PoolMembers", b =>
                {
                    b.Property<int>("PoolMembersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoolMembersId"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PoolId")
                        .HasColumnType("int");

                    b.HasKey("PoolMembersId");

                    b.HasIndex("PoolId");

                    b.ToTable("PoolMembers");
                });

            modelBuilder.Entity("IMS.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IMS.Models.Drive", b =>
                {
                    b.HasOne("IMS.Models.Employee", "AddedEmployee")
                        .WithMany("AddedEmployeeDrives")
                        .HasForeignKey("AddedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.Models.Employee", "UpdatedEmployee")
                        .WithMany("UpdatedEmployeeDrives")
                        .HasForeignKey("UpdatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedEmployee");

                    b.Navigation("UpdatedEmployee");
                });

            modelBuilder.Entity("IMS.Models.EmployeeAvailability", b =>
                {
                    b.HasOne("IMS.Models.Drive", "Drive")
                        .WithMany("DriveSoltResponse")
                        .HasForeignKey("DriveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.Models.Employee", "Employee")
                        .WithMany("EmployeeSlotResponses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drive");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("IMS.Models.EmployeeDriveResponse", b =>
                {
                    b.HasOne("IMS.Models.Drive", "Drive")
                        .WithMany("DriveResponses")
                        .HasForeignKey("DriveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IMS.Models.Employee", "Employee")
                        .WithMany("EmployeeDriveResponses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drive");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("IMS.Models.Pool", b =>
                {
                    b.HasOne("IMS.Models.Department", "department")
                        .WithMany("Pools")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("IMS.Models.PoolMembers", b =>
                {
                    b.HasOne("IMS.Models.Pool", "Pools")
                        .WithMany("PoolMembers")
                        .HasForeignKey("PoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pools");
                });

            modelBuilder.Entity("IMS.Models.Department", b =>
                {
                    b.Navigation("Pools");
                });

            modelBuilder.Entity("IMS.Models.Drive", b =>
                {
                    b.Navigation("DriveResponses");

                    b.Navigation("DriveSoltResponse");
                });

            modelBuilder.Entity("IMS.Models.Employee", b =>
                {
                    b.Navigation("AddedEmployeeDrives");

                    b.Navigation("EmployeeDriveResponses");

                    b.Navigation("EmployeeSlotResponses");

                    b.Navigation("UpdatedEmployeeDrives");
                });

            modelBuilder.Entity("IMS.Models.Pool", b =>
                {
                    b.Navigation("PoolMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
