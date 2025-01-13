using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class addAttendenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceId", "CourseId", "DateMarked", "MarkedBy", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 1, 12, 3, 11, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 1, new DateTime(2024, 1, 2, 12, 3, 11, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 1, new DateTime(2024, 1, 3, 12, 3, 11, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, 2, new DateTime(2024, 1, 4, 12, 3, 11, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 5, 1, new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 6, 1, new DateTime(2024, 1, 4, 12, 3, 11, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 7, 2, new DateTime(2024, 1, 5, 12, 3, 11, 0, DateTimeKind.Unspecified), 1, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr439", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr442", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr443", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr444", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr445", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr446", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr447", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr448", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr449", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 10,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr450", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 11,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr451", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 12,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr452", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 13,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr453", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 14,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr454", "20212025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 15,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021gsr455", "20212025" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attendances",
                keyColumn: "AttendanceId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-439", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-442", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 3,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-443", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 4,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-444", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 5,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-445", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 6,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-446", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 7,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-447", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 8,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-448", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 9,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-449", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 10,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-450", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 11,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-451", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 12,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-452", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 13,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-453", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 14,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-454", "2021-2025" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 15,
                columns: new[] { "RegistrationNo", "Session" },
                values: new object[] { "2021-gsr-455", "2021-2025" });
        }
    }
}
