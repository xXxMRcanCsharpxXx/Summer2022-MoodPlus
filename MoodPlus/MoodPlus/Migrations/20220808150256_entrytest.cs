using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodPlus.Migrations
{
    public partial class entrytest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosiNote");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1bf796ea-cd7f-40c7-9bc6-1c9beeb53d27");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Patients_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Notes_Patients_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserGoal", "UserName" },
                values: new object[] { "09a89d9b-c03f-4652-9357-c26d32451939", 0, "eb1c8d06-d830-4928-a163-29c939277673", "Account", null, false, false, null, "test", null, null, "test", null, null, false, "adc4d454-61d6-4b1f-8ea9-bdb3a21752fd", false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ReceiverId",
                table: "Notes",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SenderId",
                table: "Notes",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09a89d9b-c03f-4652-9357-c26d32451939");

            migrationBuilder.CreateTable(
                name: "PosiNote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosiNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosiNote_Patients_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PosiNote_Patients_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserGoal", "UserName" },
                values: new object[] { "1bf796ea-cd7f-40c7-9bc6-1c9beeb53d27", 0, "ba21d281-47ab-411d-948b-406d45c00eb0", "Account", null, false, false, null, "test", null, null, "test", null, null, false, "94e1c5cb-4ae0-474e-a21a-ed07050d81f9", false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_PosiNote_ReceiverId",
                table: "PosiNote",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_PosiNote_SenderId",
                table: "PosiNote",
                column: "SenderId");
        }
    }
}
