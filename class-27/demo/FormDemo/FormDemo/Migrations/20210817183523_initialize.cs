using Microsoft.EntityFrameworkCore.Migrations;

namespace FormDemo.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Owner", "Type" },
                values: new object[] { 1, 6, "Rosie", "John", 1 });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Age", "Name", "Owner", "Type" },
                values: new object[] { 2, 2, "Luna", "Char", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
