using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class Seedemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "Email",
                value: "asad@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "Email",
                value: "");
        }
    }
}
