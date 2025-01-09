using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class Addisdisabledincrtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ClassRepresentatives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 },
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 },
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 3 },
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 4 },
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 5, 5 },
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 6 },
                column: "IsDisabled",
                value: false);

            migrationBuilder.UpdateData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 7 },
                column: "IsDisabled",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ClassRepresentatives");
        }
    }
}
