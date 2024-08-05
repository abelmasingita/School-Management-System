using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class schoolfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bdf91e0-6a82-46bc-963b-9f5c2b9b0db6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d5a70ce-42b8-45d4-ad3e-c237a6d41a88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13af0735-4a15-4e0c-8003-3a48a94382fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "447e1dcd-2d98-43b9-b571-54ebf3ff5993");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstablishedYear",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrincipalName",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SchoolType",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "EstablishedYear",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "PrincipalName",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "SchoolType",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Schools");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bdf91e0-6a82-46bc-963b-9f5c2b9b0db6", null, "Parent", "PARENT" },
                    { "0d5a70ce-42b8-45d4-ad3e-c237a6d41a88", null, "Student", "STUDENT" },
                    { "13af0735-4a15-4e0c-8003-3a48a94382fb", null, "Admin", "ADMIN" },
                    { "447e1dcd-2d98-43b9-b571-54ebf3ff5993", null, "Teacher", "TEACHER" }
                });
        }
    }
}
