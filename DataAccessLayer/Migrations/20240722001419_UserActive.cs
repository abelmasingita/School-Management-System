using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "08cd301d-4f3d-425b-b58e-b8afcbfd482e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "72bfb235-b250-4f98-b1ce-4b9f7a5e53f5");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "7502cff0-5f9d-417a-838b-d34dbd538750");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "c01fc8a9-eccb-42a3-80b6-558eb23447f2");

            migrationBuilder.AddColumn<int>(
                name: "Active",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "4b4deb40-639a-4961-873d-317befd99056", null, "Parent", "PARENT" },
            //        { "74c75543-5a50-4fad-a020-efc9348a3bbb", null, "Student", "STUDENT" },
            //        { "cd3dd0a9-5d1f-465c-9fc8-8c3abe945041", null, "Admin", "ADMIN" },
            //        { "f8a19f52-369f-46f5-a046-99a31cbe477c", null, "Teacher", "TEACHER" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b4deb40-639a-4961-873d-317befd99056");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74c75543-5a50-4fad-a020-efc9348a3bbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd3dd0a9-5d1f-465c-9fc8-8c3abe945041");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8a19f52-369f-46f5-a046-99a31cbe477c");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08cd301d-4f3d-425b-b58e-b8afcbfd482e", null, "Admin", "ADMIN" },
                    { "72bfb235-b250-4f98-b1ce-4b9f7a5e53f5", null, "Teacher", "TEACHER" },
                    { "7502cff0-5f9d-417a-838b-d34dbd538750", null, "Student", "STUDENT" },
                    { "c01fc8a9-eccb-42a3-80b6-558eb23447f2", null, "Parent", "PARENT" }
                });
        }
    }
}
