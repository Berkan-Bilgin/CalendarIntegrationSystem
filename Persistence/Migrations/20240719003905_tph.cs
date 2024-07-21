using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Task_Status = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId1",
                        column: x => x.OperationClaimId1,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("97bfa56d-ce88-4755-a4b6-1560862d8fb1"), new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6080), null, "jane@example.com", null, null, new byte[] { 39, 242, 192, 65, 154, 126, 204, 38, 95, 30, 208, 86, 131, 129, 17, 100, 110, 44, 245, 109, 24, 38, 38, 96, 93, 249, 217, 48, 132, 205, 249, 147, 94, 153, 192, 161, 243, 82, 23, 134, 82, 77, 22, 3, 65, 60, 3, 176, 222, 107, 0, 206, 253, 165, 38, 255, 236, 224, 164, 44, 46, 39, 62, 36 }, new byte[] { 220, 142, 206, 141, 182, 204, 75, 49, 64, 183, 110, 137, 202, 240, 140, 196, 223, 40, 155, 146, 82, 243, 227, 54, 219, 110, 49, 19, 200, 63, 152, 216, 13, 100, 253, 28, 74, 247, 207, 243, 254, 11, 130, 125, 148, 12, 26, 66, 253, 228, 82, 93, 131, 235, 224, 4, 10, 202, 17, 129, 155, 38, 118, 1, 61, 252, 90, 58, 179, 102, 127, 87, 192, 242, 35, 200, 179, 161, 51, 21, 40, 5, 185, 229, 58, 213, 125, 160, 201, 84, 207, 237, 56, 200, 230, 55, 56, 114, 184, 249, 135, 55, 150, 103, 103, 1, 183, 215, 96, 125, 154, 180, 174, 119, 171, 233, 75, 218, 35, 227, 156, 88, 32, 187, 65, 106, 167, 185 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane_doe" },
                    { new Guid("dba1f313-b04a-46ef-9b3a-8b3ae17889de"), new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6077), null, "john@example.com", null, null, new byte[] { 227, 155, 155, 120, 43, 203, 23, 223, 110, 214, 11, 202, 206, 31, 186, 6, 88, 226, 219, 171, 20, 134, 146, 145, 142, 39, 249, 16, 246, 67, 1, 114, 159, 42, 23, 237, 77, 82, 37, 138, 18, 53, 156, 39, 84, 146, 88, 80, 63, 131, 147, 89, 140, 42, 168, 126, 21, 56, 251, 228, 154, 204, 5, 178 }, new byte[] { 183, 178, 59, 35, 25, 215, 207, 165, 142, 71, 187, 26, 195, 183, 212, 19, 4, 221, 248, 13, 82, 25, 59, 8, 118, 62, 104, 4, 115, 16, 215, 237, 69, 62, 2, 233, 209, 246, 117, 141, 1, 91, 69, 65, 166, 163, 173, 157, 86, 81, 63, 40, 192, 208, 98, 127, 179, 159, 232, 67, 133, 143, 93, 151, 89, 102, 12, 47, 255, 24, 38, 245, 164, 60, 11, 205, 190, 176, 145, 230, 248, 74, 147, 224, 192, 215, 87, 221, 23, 163, 147, 134, 226, 145, 210, 192, 152, 218, 129, 73, 245, 215, 169, 187, 188, 88, 209, 142, 128, 15, 126, 97, 199, 45, 113, 74, 97, 5, 151, 131, 255, 37, 85, 19, 99, 185, 241, 248 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john_doe" }
                });

            migrationBuilder.InsertData(
                table: "CalendarItems",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndDate", "ItemType", "Location", "StartDate", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("3bc2b265-56fe-4003-ba03-f7721055c21c"), new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6234), null, new DateTime(2024, 7, 19, 3, 39, 4, 671, DateTimeKind.Utc).AddTicks(6233), "Event", "Volkswagen Arena", new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6233), 0, "Event 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("97bfa56d-ce88-4755-a4b6-1560862d8fb1") });

            migrationBuilder.InsertData(
                table: "CalendarItems",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndDate", "ItemType", "StartDate", "Task_Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("45c1906a-2f9b-4387-9ca4-edecca7e842e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 7, 19, 8, 39, 4, 671, DateTimeKind.Utc).AddTicks(6260), "Task", new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6259), 0, "Task 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dba1f313-b04a-46ef-9b3a-8b3ae17889de") });

            migrationBuilder.InsertData(
                table: "CalendarItems",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndDate", "ItemType", "Location", "StartDate", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4d20ca45-136b-4fc3-a29f-cd76ee29d74a"), new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6231), null, new DateTime(2024, 7, 19, 2, 39, 4, 671, DateTimeKind.Utc).AddTicks(6226), "Event", "Besiktas Kultur Merkezi", new DateTime(2024, 7, 19, 0, 39, 4, 671, DateTimeKind.Utc).AddTicks(6225), 0, "Event 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dba1f313-b04a-46ef-9b3a-8b3ae17889de") });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarItems_UserId",
                table: "CalendarItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId1",
                table: "UserOperationClaims",
                column: "OperationClaimId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarItems");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
