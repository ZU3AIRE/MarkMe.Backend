using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCrsfromDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassRepresentatives",
                columns: new[] { "CourseId", "StudentId", "IsDeleted", "IsDisabled", "NominatedBy" },
                values: new object[,]
                {
                    { 1, 1, 0, false, 1 },
                    { 1, 2, 0, false, 1 },
                    { 2, 2, 0, false, 1 },
                    { 3, 2, 0, false, 1 },
                    { 4, 2, 0, false, 1 },
                    { 5, 2, 0, false, 1 },
                    { 3, 3, 0, false, 1 },
                    { 4, 4, 0, false, 1 },
                    { 5, 5, 0, false, 1 },
                    { 1, 6, 0, false, 1 },
                    { 2, 7, 0, false, 1 }
                });
        }
    }
}
