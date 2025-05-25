using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 6,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Auto Mark", "automark" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 7,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Chatbot", 0, "chatbot" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 8,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Mark Attendance", "attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 9,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Export/Share", "export" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 10,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Courses", "courses" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 11,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Students", "students" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 12,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Class Representative", "class-representatives" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 13,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Auto Mark", 1, "automark" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 14,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Chatbot", 1, "chatbot" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 15,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Mark Attendance", "attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 16,
                column: "Role",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 17,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Auto Mark", 2, "automark" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 18,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Chatbot", 2, "chatbot" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 19,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Export/Share", "export" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Label", "Role", "Url" },
                values: new object[,]
                {
                    { 20, "Courses", 3, "courses" },
                    { 21, "Students", 3, "students" },
                    { 22, "Class Representative", 3, "class-representatives" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 6,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Chatbot", "chatbot" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 7,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Mark Attendance", 1, "attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 8,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Export/Share", "export" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 9,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Courses", "courses" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 10,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Students", "students" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 11,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Class Representative", "class-representatives" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 12,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Chatbot", "chatbot" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 13,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Mark Attendance", 2, "attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 14,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Export/Share", 2, "export" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 15,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Chatbot", "chatbot" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 16,
                column: "Role",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 17,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Courses", 3, "courses" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 18,
                columns: new[] { "Label", "Role", "Url" },
                values: new object[] { "Students", 3, "students" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 19,
                columns: new[] { "Label", "Url" },
                values: new object[] { "Class Representative", "class-representatives" });
        }
    }
}
