using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marvin.IDP.Migrations.IdentityDb
{
    public partial class InitialUserDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecurityCodeExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProviderIdentityKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSecrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecrets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSecrets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "424ed4e5-718a-40a5-bab7-56dbfb6f4749", "david@someprovider.com", "AQAAAAEAACcQAAAAEIi0HEeTvqcxwhA+dR/RKOEIfdGn1VIKy0P+AhKOp5vIdsb80zmPxqbhxllt5AmkKg==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d860efca-22d9-47fd-8249-791ba61b07c7", "David" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Email", "Password", "SecurityCode", "SecurityCodeExpirationDate", "Subject", "UserName" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "546b3451-fa22-4fd5-bc66-d57953de3afb", "emma@someprovider.com", "AQAAAAEAACcQAAAAEHgXILmaP4pu/Kz8M2cASmfD/XsHykcmTNyFTvQQiwyWaLWjWAlxBH1L5pQfSyRYqw==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "Emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("1ef54f66-856c-4ebe-ae30-30ccfbce23fa"), "d1d25486-f22f-4c61-b6d5-86b4900d0e55", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("3d83385c-a36a-4f76-a26c-42d413f11569"), "4537aeeb-1357-45fd-89d6-732686315145", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("46a9f1ab-f427-449d-9c13-1e1cb9c31d60"), "b7146016-58b3-4b81-9c86-edb5d3daa288", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("47c36985-5b02-4963-ab86-55c8f212d94e"), "9074e5fe-1148-4a92-b199-ee817ca5dadf", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("957d230c-a888-4799-aba3-99df16c7ef79"), "f55bbe22-9028-4e47-9633-21a2b72bff25", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("c6ed0545-9ad2-4bfd-98b7-ebcb8fed16f1"), "ba36aa68-3dfb-4cac-ad95-819d499e7fcf", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("e118b97a-59f1-4aee-89aa-287846944eee"), "9f1936fd-900b-4490-b608-995da7168a72", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("f4de1615-5763-4ef2-983c-23adb60c4939"), "5d5d9ce5-f328-449f-a142-a565d430de99", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecrets_UserId",
                table: "UserSecrets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserSecrets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
