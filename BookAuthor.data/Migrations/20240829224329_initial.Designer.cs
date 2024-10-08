﻿// <auto-generated />
using System;
using BookManagement.data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookAuthor.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240829224329_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAuthor.Models.Models.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0c88bdce-c4d3-433c-aa0e-a321c0220284"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(612),
                            Name = "Comedy",
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(613)
                        },
                        new
                        {
                            Id = new Guid("7b5201ef-52f5-41fa-a610-7d2112d6dc61"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(615),
                            Name = "Sci fi",
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(615)
                        },
                        new
                        {
                            Id = new Guid("270cce65-a05f-4608-9153-4449a85d4dd9"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(617),
                            Name = "Medieval",
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(617)
                        });
                });

            modelBuilder.Entity("BookAuthor.Models.Models.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"),
                            PermissionId = new Guid("50c90ec9-f9bc-4325-9522-46a2254377d3"),
                            Id = new Guid("a7e77897-2c04-41da-93e4-27146cca339b")
                        },
                        new
                        {
                            RoleId = new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"),
                            PermissionId = new Guid("b34afccd-4285-411b-b4be-2b4afd457fc1"),
                            Id = new Guid("f918ebe2-dbc2-4f7b-8f77-875c12d81fcf")
                        },
                        new
                        {
                            RoleId = new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"),
                            PermissionId = new Guid("a75f0645-3593-450f-80a1-72fb17741e5a"),
                            Id = new Guid("2084a816-18cc-4035-b5df-53b62ef86391")
                        },
                        new
                        {
                            RoleId = new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"),
                            PermissionId = new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"),
                            Id = new Guid("63295b47-251b-4a70-b160-16018448190b")
                        },
                        new
                        {
                            RoleId = new Guid("01987000-f51f-41e3-a46e-7ae406a46664"),
                            PermissionId = new Guid("50c90ec9-f9bc-4325-9522-46a2254377d3"),
                            Id = new Guid("f5933827-46a7-4856-bb6e-4731432e02d4")
                        },
                        new
                        {
                            RoleId = new Guid("01987000-f51f-41e3-a46e-7ae406a46664"),
                            PermissionId = new Guid("b34afccd-4285-411b-b4be-2b4afd457fc1"),
                            Id = new Guid("2029e27a-a537-4585-a619-5410c448ccb8")
                        },
                        new
                        {
                            RoleId = new Guid("01987000-f51f-41e3-a46e-7ae406a46664"),
                            PermissionId = new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"),
                            Id = new Guid("2fc01953-33d5-4eb9-a01f-d932575fc079")
                        },
                        new
                        {
                            RoleId = new Guid("217d9a60-061a-460d-a760-6e40003423b1"),
                            PermissionId = new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"),
                            Id = new Guid("7166d452-54fb-4509-bf0e-74930d05b7cb")
                        });
                });

            modelBuilder.Entity("BookAuthor.Models.models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PermissionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("50c90ec9-f9bc-4325-9522-46a2254377d3"),
                            PermissionType = "CREATE"
                        },
                        new
                        {
                            Id = new Guid("b34afccd-4285-411b-b4be-2b4afd457fc1"),
                            PermissionType = "UPDATE"
                        },
                        new
                        {
                            Id = new Guid("a75f0645-3593-450f-80a1-72fb17741e5a"),
                            PermissionType = "VIEW"
                        },
                        new
                        {
                            Id = new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"),
                            PermissionType = "DELETE"
                        });
                });

            modelBuilder.Entity("BookAuthor.Models.models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"),
                            Name = "ROLE_SUPER_ADMIN"
                        },
                        new
                        {
                            Id = new Guid("01987000-f51f-41e3-a46e-7ae406a46664"),
                            Name = "ROLE_ADMIN"
                        },
                        new
                        {
                            Id = new Guid("217d9a60-061a-460d-a760-6e40003423b1"),
                            Name = "ROLE_USER"
                        });
                });

            modelBuilder.Entity("BookAuthor.Models.models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b83a39e4-86d2-4286-82d2-d0c024671c59"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5087),
                            Email = "email@email.com",
                            Name = "User1",
                            Password = "Password",
                            RoleId = new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"),
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5090),
                            UserName = "username1"
                        },
                        new
                        {
                            Id = new Guid("de4ac71f-5a1e-4b8c-85ce-c462e4454b63"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5094),
                            Email = "email2@email.com",
                            Name = "User2",
                            Password = "Password2",
                            RoleId = new Guid("01987000-f51f-41e3-a46e-7ae406a46664"),
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5094),
                            UserName = "username2"
                        },
                        new
                        {
                            Id = new Guid("71ce9c91-8974-4eb0-a2ba-437eec54f475"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5096),
                            Email = "email3@email.com",
                            Name = "User3",
                            Password = "Password3",
                            RoleId = new Guid("217d9a60-061a-460d-a760-6e40003423b1"),
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5096),
                            UserName = "username3"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Models.models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = new Guid("680313e5-f5a6-449a-8ca6-fb7cf3924bca"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(432),
                            Name = "Gabriel García Marquez",
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(445)
                        },
                        new
                        {
                            Id = new Guid("5aeceae2-a79c-491d-bda8-d08d6afd45bb"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(468),
                            Name = "Pablo Neruda",
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(468)
                        },
                        new
                        {
                            Id = new Guid("1e2cf504-46ea-4fd6-999a-9c00fe25f320"),
                            CreatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(470),
                            Name = "Edgar Alan Poe",
                            UpdatedAt = new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(470)
                        });
                });

            modelBuilder.Entity("Models.models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookAuthor.Models.Models.RolePermission", b =>
                {
                    b.HasOne("BookAuthor.Models.models.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAuthor.Models.models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookAuthor.Models.models.User", b =>
                {
                    b.HasOne("BookAuthor.Models.models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.models.Book", b =>
                {
                    b.HasOne("Models.models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAuthor.Models.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookAuthor.Models.models.Permission", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("BookAuthor.Models.models.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
