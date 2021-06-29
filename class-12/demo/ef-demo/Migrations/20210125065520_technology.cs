using Microsoft.EntityFrameworkCore.Migrations;

namespace ef_demo.Migrations
{
    public partial class technology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, ".NET " });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Node.js" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Technologies");
        }
    }
}
