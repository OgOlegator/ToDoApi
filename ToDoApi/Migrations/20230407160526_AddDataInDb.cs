using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDataInDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Test 1" },
                    { "2", "Test 2" },
                    { "3", "Test 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
