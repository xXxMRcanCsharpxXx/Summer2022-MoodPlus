using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoodPlus.Migrations
{
    public partial class noteIndexFixAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f90ffeda-32e6-4ebb-8257-74d8f9b34b92", "f265450c-abbe-4856-a930-686f8473535c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "test",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f11c8a1a-5226-45c8-8d34-3ac84baca79e", "2be44368-c4b8-429b-9c97-c1348a6dcbd3" });
        }
    }
}
