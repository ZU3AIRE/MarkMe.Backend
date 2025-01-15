using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarkMe.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Label", "Role", "Url" },
                values: new object[,]
                {
                    { 1, "Mark Attendance", 0, "attendance" },
                    { 2, "Export/Share", 0, "export" },
                    { 3, "Courses", 0, "courses" },
                    { 4, "Students", 0, "students" },
                    { 5, "Class Representative", 0, "class-representative" },
                    { 6, "Mark Attendance", 1, "attendance" },
                    { 7, "Export/Share", 1, "export" },
                    { 8, "Courses", 1, "courses" },
                    { 9, "Students", 1, "students" },
                    { 10, "Class Representative", 1, "class-representative" },
                    { 11, "Mark Attendance", 2, "attendance" },
                    { 12, "Export/Share", 2, "export" },
                    { 14, "Export/Share", 3, "export" },
                    { 15, "Courses", 3, "courses" },
                    { 16, "Students", 3, "students" },
                    { 17, "Class Representative", 3, "class-representative" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
