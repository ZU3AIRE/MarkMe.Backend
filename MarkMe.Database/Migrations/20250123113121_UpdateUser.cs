using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "CollegeRollNo", "RegistrationNo", "UniversityRollNo" },
                values: new object[] { "501", "2021gsr407", "070982" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "markmecr@tohru.org", "MarkMe@12" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "markmetutor@tohru.org", "MarkMe@12" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "IsDeleted", "LastName", "Password" },
                values: new object[] { 3, "markmeadmin@tohru.org", "Mousa", false, "Naeem", "MarkMe@12" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "CollegeRollNo", "RegistrationNo", "UniversityRollNo" },
                values: new object[] { "537", "2021gsr439", "070941" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "xubairjamil@gmail.com", "123456" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "umairjamil@gmail.com", "123456" });
        }
    }
}
