using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class urlfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 5,
                column: "Url",
                value: "class-representatives");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 10,
                column: "Url",
                value: "class-representatives");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 17,
                column: "Url",
                value: "class-representatives");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 5,
                column: "Url",
                value: "class-representative");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 10,
                column: "Url",
                value: "class-representative");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 17,
                column: "Url",
                value: "class-representative");
        }
    }
}
