using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.HotelID, x.RoomNumber });
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    AmenitiesID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.RoomID, x.AmenitiesID });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenitiesID",
                        column: x => x.AmenitiesID,
                        principalTable: "Amenities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Mini Bar" },
                    { 2, "Coffee Maker" },
                    { 3, "Jacuzzi Tub" },
                    { 4, "Netflix" },
                    { 5, "Petting Zoo" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Seattle Way", "Emerald City Stay", "123-456-7654" },
                    { 2, "123 LasVegas Strip Way", "Las Vegas Strip", "123-876-1946" },
                    { 3, "987 Dizney Way", "Disney Adventures", "481-512-3421" },
                    { 4, "84 Treasure Way", "Pirates Life", "975-588-9621" },
                    { 5, "123 Fancy Way", "Grand Excursion", "493-396-9785" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Seahawks Snooze" },
                    { 2, 0, "Restful Rainier" },
                    { 3, 1, "Couples Retreat" },
                    { 4, 2, "Officially Business" },
                    { 5, 0, "The Playhouse" },
                    { 6, 1, "The Staycation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesID",
                table: "RoomAmenities",
                column: "AmenitiesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
