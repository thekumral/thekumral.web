using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace thekumral.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"), "0291cae2-ca10-404f-96dc-65427e87143e", "Superadmin", "SUPERADMIN" },
                    { new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"), "e940627b-9425-4f59-9bf2-7a07b5f07d1e", "Companyadmin", "COMPANYADMIN" },
                    { new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"), "138eb8ff-3538-435e-a810-8861ad23ddb5", "Companyauthor", "COMPANYAUTHOR" },
                    { new Guid("edf6c246-41d8-475f-8d92-41dddac5aefb"), "052230ce-9a8f-48e5-98e7-40aa409cd4d0", "DefaultUser", "DEFAULTUSER" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "Description", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f032c"), "Super Admin", null, null, "Description", false, null, null, "CodeLikeARose" },
                    { new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f044c"), "Super Admin", null, null, "Description", false, null, null, "Kumrals" },
                    { new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "Super Admin", null, null, "Description", false, null, null, "thekumral" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0111"), 0, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "5b37b359-57de-414d-902e-ad0e313c4d67", "default@apadesign.net", false, "Default", "USER", false, null, "DEFAULT@APADESIGN.NET", "DEFAULTUSER", "AQAAAAIAAYagAAAAEF7ch6tGsNlDB0AJ+iI/XQlR+LgQO4GoBb8Rk6MLMeP1Oq6ZATqg97Ax7X1qKr6Ifg==", "", false, null, null, "faf6744a-8b8c-47a5-a549-0719b4f85891", false, "defaultUser" },
                    { new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0222"), 0, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f044c"), "fce9de52-ee9b-473d-bbdf-a3c635d0b63d", "omer@kumral.com", false, "Ömer Faruk", "KUMRAL", false, null, "OMER@KUMRAL.COM", "", "AQAAAAIAAYagAAAAEDS7IU3vHVUEkAlvLRbswrjOLV/84aYeBe3sCaysfR2b/3P8y2SK85qjEK1J0JHAeA==", "+905494000602", false, null, null, "d723f48f-5ece-4b51-bb81-2c1d61f1f8a0", false, "" },
                    { new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0413"), 0, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "c3ee34d5-c10b-4187-b400-c97b6e026c38", "Mustafa@apadesign.net", false, "Mustafa", "KUMRAL", false, null, "MUSTAFA@APADESIGN.NET", "COMPANYAUTHORFORAPA", "AQAAAAIAAYagAAAAEOw4LqPyUYLek2dJX2z5c6jqBTJRmw54BhOKu59d0FAoTyWITcpc0njKBfVvF9NzQg==", "+905302238522", false, null, null, "a3f375c1-8597-4df4-b39e-274f76bd75a6", false, "companyAuthorForApa" },
                    { new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"), 0, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "a8474f8c-bde2-455d-a43c-0edbc5fec83f", "mahmutkumral@apadesign.net", false, "Mahmut", "KUMRAL", false, null, "MAHMUTKUMRAL@APADESIGN.NET", "COMPANYADMINFORAPA", "AQAAAAIAAYagAAAAEN6nnydOOSREg0Ospt71EaAKCZF0TH5mSXgMJh3Y+XpxhBWJaEedxSCSbMvsHqUVmg==", "+905363282325", false, null, null, "bbaaafad-ddbb-438e-97c7-7ce641728519", false, "CompanyAdminForApa" },
                    { new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0431"), 0, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f044c"), "6077f85a-593d-4be4-90b7-952b8739aea0", "thekumral@kumral.com", false, "Ömer Faruk", "KUMRAL", false, null, "THEKUMRAL@KUMRAL.COM", "THEKUMRAL", "AQAAAAIAAYagAAAAEFPgGo+VXKyOSQ0oDzzqjzUxIDJ8jWuZ4sop1d91J035Gp/I8IQcSZl5q/6XWiMgjg==", "+905494000602", false, null, null, "651a00ba-4b03-47e2-9afa-b7fe8894042f", false, "thekumral" },
                    { new Guid("cb94223b-ccb8-4f2f-94d7-0df96a7f012c"), 0, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "7b61eb99-363f-4c3a-b62b-519a62672f2d", "info@apadesign.net", false, "SuperMahmut", "KUMRAL", false, null, "INFO@APADESIGN.NET", "SUPERADMINAPA", "AQAAAAIAAYagAAAAEEF02cuZj806poFtwVFXcj8/eeJuTkcgBA6eBLTb/08OzAEd65QU/frKwYAdmzr3dQ==", "+905439999999", false, null, null, "628a68fb-e8df-4a1f-a3da-57da7788221f", false, "SuperAdminApa" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("edf6c246-41d8-475f-8d92-41dddac5aefb"), new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0111") },
                    { new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"), new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0222") },
                    { new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"), new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0413") },
                    { new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"), new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"), new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0431") },
                    { new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"), new Guid("cb94223b-ccb8-4f2f-94d7-0df96a7f012c") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "Deneme", null, null, false, null, null, "C# Nedir ?", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f061c"), "Deneme", null, null, false, null, null, "Visual Studio - Vs Code Çatışması", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "CompanyId", "Content", "CreatedBy", "CreatedDate", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "ShortContent", "Title", "Url", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8e32c0b6-5884-4aca-ac92-e203545386a0"), new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f044c"), "Asp.net Core Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.", "Admin Test", new DateTime(2024, 7, 5, 22, 26, 16, 938, DateTimeKind.Local).AddTicks(3976), null, false, null, null, "Short Content", "Asp.net Core Deneme Makalesi 1", "www.google.com", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0222"), 15 },
                    { new Guid("fdd39015-31fe-4df7-bf5b-659d54173080"), new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f044c"), "Visual Studio Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.", "Admin Test", new DateTime(2024, 7, 5, 22, 26, 16, 938, DateTimeKind.Local).AddTicks(3995), null, false, null, null, "Short Content", "Visual Studio Deneme Makalesi 1", "www.google.com", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0222"), 15 }
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
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CompanyId",
                table: "Categories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
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
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
