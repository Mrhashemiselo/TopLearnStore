﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopLearn.DataLayer.Context;

#nullable disable

namespace TopLearn.DataLayer.Migrations
{
    [DbContext(typeof(TopLearnContext))]
    partial class TopLearnContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseLevel")
                        .HasColumnType("int");

                    b.Property<int>("CourseStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DemoFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("SubGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubGroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseEpisode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEpisodes");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActiveCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Users.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Wallet.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WalletTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletTypeId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Wallet.WalletType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("WalletTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "واریز"
                        },
                        new
                        {
                            Id = 2,
                            Title = "برداشت"
                        });
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.Course", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseGroup", "CourseGroup")
                        .WithMany("Courses")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseGroup", "SubGroup")
                        .WithMany("SubCourses")
                        .HasForeignKey("SubGroupId");

                    b.HasOne("TopLearn.DataLayer.Entities.Users.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseGroup");

                    b.Navigation("SubGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseEpisode", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Course.Course", "Course")
                        .WithMany("CourseEpisodes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseGroup", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Course.CourseGroup", null)
                        .WithMany("CourseGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permission", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Permissions.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.RolePermission", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Users.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Users.UserRole", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Users.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Wallet.Wallet", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Users.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DataLayer.Entities.Wallet.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("WalletTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WalletType");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.Course", b =>
                {
                    b.Navigation("CourseEpisodes");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Course.CourseGroup", b =>
                {
                    b.Navigation("CourseGroups");

                    b.Navigation("Courses");

                    b.Navigation("SubCourses");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Users.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Users.User", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("UserRoles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Wallet.WalletType", b =>
                {
                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}
