using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookAuthor.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1e2cf504-46ea-4fd6-999a-9c00fe25f320"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(470), "Edgar Alan Poe", new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(470) },
                    { new Guid("5aeceae2-a79c-491d-bda8-d08d6afd45bb"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(468), "Pablo Neruda", new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(468) },
                    { new Guid("680313e5-f5a6-449a-8ca6-fb7cf3924bca"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(432), "Gabriel García Marquez", new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(445) }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0c88bdce-c4d3-433c-aa0e-a321c0220284"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(612), "Comedy", new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(613) },
                    { new Guid("270cce65-a05f-4608-9153-4449a85d4dd9"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(617), "Medieval", new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(617) },
                    { new Guid("7b5201ef-52f5-41fa-a610-7d2112d6dc61"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(615), "Sci fi", new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(615) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "PermissionType" },
                values: new object[,]
                {
                    { new Guid("50c90ec9-f9bc-4325-9522-46a2254377d3"), "CREATE" },
                    { new Guid("a75f0645-3593-450f-80a1-72fb17741e5a"), "VIEW" },
                    { new Guid("b34afccd-4285-411b-b4be-2b4afd457fc1"), "UPDATE" },
                    { new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"), "DELETE" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("01987000-f51f-41e3-a46e-7ae406a46664"), "ROLE_ADMIN" },
                    { new Guid("217d9a60-061a-460d-a760-6e40003423b1"), "ROLE_USER" },
                    { new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"), "ROLE_SUPER_ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("50c90ec9-f9bc-4325-9522-46a2254377d3"), new Guid("01987000-f51f-41e3-a46e-7ae406a46664"), new Guid("f5933827-46a7-4856-bb6e-4731432e02d4") },
                    { new Guid("b34afccd-4285-411b-b4be-2b4afd457fc1"), new Guid("01987000-f51f-41e3-a46e-7ae406a46664"), new Guid("2029e27a-a537-4585-a619-5410c448ccb8") },
                    { new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"), new Guid("01987000-f51f-41e3-a46e-7ae406a46664"), new Guid("2fc01953-33d5-4eb9-a01f-d932575fc079") },
                    { new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"), new Guid("217d9a60-061a-460d-a760-6e40003423b1"), new Guid("7166d452-54fb-4509-bf0e-74930d05b7cb") },
                    { new Guid("50c90ec9-f9bc-4325-9522-46a2254377d3"), new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"), new Guid("a7e77897-2c04-41da-93e4-27146cca339b") },
                    { new Guid("a75f0645-3593-450f-80a1-72fb17741e5a"), new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"), new Guid("2084a816-18cc-4035-b5df-53b62ef86391") },
                    { new Guid("b34afccd-4285-411b-b4be-2b4afd457fc1"), new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"), new Guid("f918ebe2-dbc2-4f7b-8f77-875c12d81fcf") },
                    { new Guid("e2d702b9-deda-4e86-8883-abfc0088f000"), new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"), new Guid("63295b47-251b-4a70-b160-16018448190b") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "RoleId", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("71ce9c91-8974-4eb0-a2ba-437eec54f475"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5096), "email3@email.com", "User3", "Password3", new Guid("217d9a60-061a-460d-a760-6e40003423b1"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5096), "username3" },
                    { new Guid("b83a39e4-86d2-4286-82d2-d0c024671c59"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5087), "email@email.com", "User1", "Password", new Guid("9777059c-1879-4401-8a34-56f56cc1bfb2"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5090), "username1" },
                    { new Guid("de4ac71f-5a1e-4b8c-85ce-c462e4454b63"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5094), "email2@email.com", "User2", "Password2", new Guid("01987000-f51f-41e3-a46e-7ae406a46664"), new DateTime(2024, 8, 29, 17, 43, 29, 11, DateTimeKind.Local).AddTicks(5094), "username2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
