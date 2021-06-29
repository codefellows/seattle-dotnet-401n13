using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDemo.Migrations
{
  public partial class initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Students",
          columns: table => new
          {
            Id = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Students", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Students");
    }
  }
}
