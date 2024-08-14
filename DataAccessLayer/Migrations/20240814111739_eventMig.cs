using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class eventMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08ae1694-3004-4878-bfdb-a49672e97d46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f1de3ac-5ea8-4994-9f70-a2ce4b8eb43d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "878fd283-53cb-4e05-b216-508b854c98de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e276ec25-9d85-4bb9-b834-f79ce2c303ff");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833c6bee-6acc-4b63-9e5b-af14676dba6b", null, "Student", "STUDENT" },
                    { "8e3bc13a-4e49-41f4-a04b-ef58c91af0da", null, "Admin", "ADMIN" },
                    { "e54b62d4-963d-4eec-941e-b7da4995c1b9", null, "Parent", "PARENT" },
                    { "f3478d33-8721-46fd-94a8-be124f589164", null, "Teacher", "TEACHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833c6bee-6acc-4b63-9e5b-af14676dba6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e3bc13a-4e49-41f4-a04b-ef58c91af0da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e54b62d4-963d-4eec-941e-b7da4995c1b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3478d33-8721-46fd-94a8-be124f589164");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08ae1694-3004-4878-bfdb-a49672e97d46", null, "Student", "STUDENT" },
                    { "6f1de3ac-5ea8-4994-9f70-a2ce4b8eb43d", null, "Parent", "PARENT" },
                    { "878fd283-53cb-4e05-b216-508b854c98de", null, "Admin", "ADMIN" },
                    { "e276ec25-9d85-4bb9-b834-f79ce2c303ff", null, "Teacher", "TEACHER" }
                });
        }
    }
}
