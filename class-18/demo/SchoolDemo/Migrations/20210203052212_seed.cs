using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDemo.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "Price", "TechnologyId" },
                values: new object[] { 1, "dotnet-401d12", 4000f, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "Price", "TechnologyId" },
                values: new object[] { 2, "javascript-401n17", 4000f, 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2020, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Test", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
