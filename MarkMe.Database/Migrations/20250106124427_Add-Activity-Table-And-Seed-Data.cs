using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "creditHoursPerWeek",
                table: "Courses",
                newName: "CreditHoursPerWeek");

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassRepresentativeStudentId = table.Column<int>(type: "int", nullable: false),
                    ClassRepresentativeCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_ClassRepresentatives_ClassRepresentativeStudentId_ClassRepresentativeCourseId",
                        columns: x => new { x.ClassRepresentativeStudentId, x.ClassRepresentativeCourseId },
                        principalTable: "ClassRepresentatives",
                        principalColumns: new[] { "StudentId", "CourseId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassRepresentatives",
                columns: new[] { "CourseId", "StudentId", "IsDeleted", "NominatedBy" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 2, 0, 1 },
                    { 3, 3, 0, 1 },
                    { 4, 4, 0, 1 },
                    { 5, 5, 0, 1 },
                    { 1, 6, 0, 1 },
                    { 2, 7, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "AssignedTo", "Code", "CreditHours", "CreditHoursPerWeek", "IsArchived", "Semester", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 1, "CS101", 120, 4, false, 1, "Introduction to Computing", 1 },
                    { 2, 1, "CS102", 120, 4, false, 1, "Programming Fundamentals", 1 },
                    { 3, 1, "CS103", 120, 4, false, 1, "Discrete Mathematics", 1 },
                    { 4, 1, "CS104", 120, 4, false, 1, "Calculus", 1 },
                    { 5, 1, "CS105", 120, 4, false, 1, "English", 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CollegeRollNo", "FirstName", "IsDeleted", "LastName", "RegistrationNo", "Section", "Session", "UniversityRollNo" },
                values: new object[,]
                {
                    { 3, "540", "Ali", false, "Senior", "2021-gsr-443", "G1", "2021-2025", "070944" },
                    { 4, "541", "Ahmed", false, "Ali", "2021-gsr-444", "G1", "2021-2025", "070945" },
                    { 5, "542", "Asad", false, "Mojenzo", "2021-gsr-445", "G1", "2021-2025", "070946" },
                    { 6, "543", "Ahsan", false, "Dildar", "2021-gsr-446", "G1", "2021-2025", "070947" },
                    { 7, "544", "Minal", false, "Asgher", "2021-gsr-447", "G1", "2021-2025", "070948" },
                    { 8, "545", "Wajeeha", false, "Maqsood", "2021-gsr-448", "G1", "2021-2025", "070949" },
                    { 9, "546", "Mahnoor", false, "Aqdas", "2021-gsr-449", "G1", "2021-2025", "070950" },
                    { 10, "547", "Nasir", false, "Aslam", "2021-gsr-450", "G1", "2021-2025", "070951" },
                    { 11, "548", "Mehrooz", false, "Atif", "2021-gsr-451", "G1", "2021-2025", "070952" },
                    { 12, "549", "Akther", false, "Ali", "2021-gsr-452", "G1", "2021-2025", "070953" },
                    { 13, "550", "Adeel", false, "Abbas", "2021-gsr-453", "G1", "2021-2025", "070954" },
                    { 14, "551", "Rohan", false, "Shahmeer", "2021-gsr-454", "G1", "2021-2025", "070955" },
                    { 15, "552", "Amber", false, "Shamraiz", "2021-gsr-455", "G1", "2021-2025", "070956" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "IsDeleted", "LastName", "Password" },
                values: new object[] { 2, "umairjamil@gmail.com", "Umair", false, "Jamil", "123456" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ClassRepresentativeCourseId", "ClassRepresentativeStudentId", "Date", "Description" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Introduction to Computing" },
                    { 2, 2, 2, new DateTime(2024, 1, 2, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Programming Fundamentals" },
                    { 3, 3, 3, new DateTime(2024, 1, 3, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Discrete Mathematics" },
                    { 4, 4, 4, new DateTime(2024, 1, 4, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Calculus" },
                    { 5, 5, 5, new DateTime(2024, 1, 6, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for English" },
                    { 6, 1, 1, new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Introduction to Computing" },
                    { 7, 2, 2, new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Programming Fundamentals" },
                    { 8, 3, 3, new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Discrete Mathematics" },
                    { 9, 4, 4, new DateTime(2024, 1, 6, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Calculus" },
                    { 10, 5, 5, new DateTime(2024, 1, 6, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for English" },
                    { 11, 1, 6, new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Introduction to Computing" },
                    { 12, 2, 7, new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified), "Marked Attendance for Programming Fundamentals" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ClassRepresentativeStudentId_ClassRepresentativeCourseId",
                table: "Activities",
                columns: new[] { "ClassRepresentativeStudentId", "ClassRepresentativeCourseId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ClassRepresentatives",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 2 });

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

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "CreditHoursPerWeek",
                table: "Courses",
                newName: "creditHoursPerWeek");
        }
    }
}
