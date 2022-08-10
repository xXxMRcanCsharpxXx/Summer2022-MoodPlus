using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodPlus.Migrations
{
    public partial class login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "Patients",
                newName: "NextLogin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78062c1e-1a42-4b0e-a477-20dcc040cfc1", "194e08ed-2fb4-46a2-9f5a-0e0506a6eb0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NextLogin",
                table: "Patients",
                newName: "LastLogin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a75d1c70-8473-424e-897d-cf8ce9e8420a", "bde84e3f-859b-4539-a5bd-19e1130946ed" });
        }
    }
}
