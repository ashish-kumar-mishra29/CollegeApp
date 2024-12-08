using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CollegeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "StudentName" },
                values: new object[,]
                {
                    { 1, "India", new DateTime(2001, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ashish@gmail.com", "Ashish" },
                    { 2, "London", new DateTime(1997, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "james@gmail.com", "James" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
