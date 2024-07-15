using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
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
                    { new Guid("370ebb87-c905-4c1b-85b9-119776587994"), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2388), null, "john@example.com", null, null, new byte[] { 156, 166, 25, 222, 248, 106, 190, 236, 237, 245, 248, 197, 240, 154, 160, 50, 74, 64, 170, 127, 179, 237, 172, 217, 226, 66, 6, 61, 110, 232, 183, 238, 230, 226, 72, 42, 160, 114, 181, 66, 107, 83, 96, 151, 209, 231, 61, 90, 166, 201, 121, 4, 61, 115, 31, 124, 30, 15, 2, 21, 131, 14, 53, 171 }, new byte[] { 75, 9, 32, 39, 239, 45, 229, 63, 3, 183, 58, 43, 175, 188, 50, 85, 254, 7, 215, 211, 11, 113, 177, 45, 141, 235, 249, 208, 228, 8, 166, 72, 141, 35, 181, 56, 65, 89, 189, 222, 227, 162, 109, 230, 97, 78, 248, 242, 134, 69, 165, 62, 190, 153, 225, 44, 223, 228, 116, 216, 223, 101, 160, 195, 55, 213, 137, 216, 178, 90, 158, 172, 101, 19, 105, 55, 20, 195, 154, 140, 65, 86, 121, 248, 195, 156, 98, 82, 5, 105, 16, 177, 18, 180, 245, 125, 55, 235, 243, 133, 172, 208, 4, 99, 88, 185, 17, 68, 142, 8, 152, 148, 9, 55, 249, 160, 215, 21, 36, 208, 88, 250, 230, 112, 61, 11, 138, 65 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john_doe" },
                    { new Guid("ef2c7840-dbef-4a92-974f-63059500c535"), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2390), null, "jane@example.com", null, null, new byte[] { 255, 162, 198, 138, 194, 153, 129, 57, 229, 153, 208, 9, 46, 79, 63, 61, 32, 238, 201, 69, 42, 26, 219, 240, 71, 215, 221, 42, 148, 248, 68, 83, 252, 165, 62, 99, 195, 167, 244, 51, 131, 78, 90, 82, 199, 3, 89, 97, 246, 210, 145, 216, 82, 239, 8, 123, 166, 115, 173, 210, 90, 39, 176, 63 }, new byte[] { 146, 53, 83, 205, 249, 237, 74, 154, 37, 5, 225, 150, 141, 33, 161, 101, 187, 152, 255, 214, 45, 241, 119, 43, 168, 151, 106, 12, 68, 52, 197, 24, 240, 230, 128, 252, 8, 4, 164, 100, 233, 73, 35, 122, 16, 112, 15, 240, 71, 137, 165, 209, 13, 167, 57, 3, 101, 54, 239, 149, 85, 244, 145, 225, 17, 241, 113, 223, 242, 68, 108, 156, 224, 62, 162, 58, 30, 28, 212, 98, 115, 8, 54, 6, 167, 44, 201, 213, 107, 148, 123, 38, 26, 212, 244, 187, 240, 94, 253, 224, 193, 180, 213, 13, 218, 142, 165, 156, 142, 26, 41, 233, 185, 7, 113, 207, 6, 36, 201, 28, 153, 122, 6, 112, 66, 89, 234, 66 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane_doe" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndDate", "StartDate", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("5dad0354-16ef-4c78-8576-d995c514195c"), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2529), null, new DateTime(2024, 7, 11, 3, 29, 12, 786, DateTimeKind.Utc).AddTicks(2528), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2528), 0, "Event 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ef2c7840-dbef-4a92-974f-63059500c535") },
                    { new Guid("e14ab769-9bbd-415e-be0a-3e57f162ebff"), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2525), null, new DateTime(2024, 7, 11, 2, 29, 12, 786, DateTimeKind.Utc).AddTicks(2520), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2520), 0, "Event 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("370ebb87-c905-4c1b-85b9-119776587994") }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "EndDate", "StartDate", "Status", "Title", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d81c8cf3-04c0-46c8-a098-77190b64eda8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2024, 7, 11, 8, 29, 12, 786, DateTimeKind.Utc).AddTicks(2556), new DateTime(2024, 7, 11, 0, 29, 12, 786, DateTimeKind.Utc).AddTicks(2555), 0, "Task 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("370ebb87-c905-4c1b-85b9-119776587994") });

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
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
                name: "Events");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
