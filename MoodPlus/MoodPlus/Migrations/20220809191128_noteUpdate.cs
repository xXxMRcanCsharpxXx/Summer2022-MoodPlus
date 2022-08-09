using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodPlus.Migrations
{
    public partial class noteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f11c8a1a-5226-45c8-8d34-3ac84baca79e", "2be44368-c4b8-429b-9c97-c1348a6dcbd3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a75d1c70-8473-424e-897d-cf8ce9e8420a", "bde84e3f-859b-4539-a5bd-19e1130946ed" });
        }
    }
}
