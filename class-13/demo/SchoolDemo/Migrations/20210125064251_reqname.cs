using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDemo.Migrations
{
  public partial class reqname : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
          name: "LastName",
          table: "Students",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "nvarchar(max)",
          oldNullable: true);

      migrationBuilder.AlterColumn<string>(
          name: "FirstName",
          table: "Students",
          type: "nvarchar(max)",
          nullable: false,
          defaultValue: "",
          oldClrType: typeof(string),
          oldType: "nvarchar(max)",
          oldNullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
          name: "LastName",
          table: "Students",
          type: "nvarchar(max)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(max)");

      migrationBuilder.AlterColumn<string>(
          name: "FirstName",
          table: "Students",
          type: "nvarchar(max)",
          nullable: true,
          oldClrType: typeof(string),
          oldType: "nvarchar(max)");
    }
  }
}
