using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class Updatestudentconstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_CollegeRollNo",
                table: "Students",
                column: "CollegeRollNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityRollNo",
                table: "Students",
                column: "UniversityRollNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_CollegeRollNo",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UniversityRollNo",
                table: "Students");
        }
    }
}
