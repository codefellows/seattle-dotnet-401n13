using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInn.Migrations
{
    public partial class addedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Room_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Room_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Rooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRooms_Rooms_RoomID",
                table: "HotelRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenities_Rooms_RoomID",
                table: "RoomAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRooms_Room_RoomID",
                table: "HotelRooms",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenities_Room_RoomID",
                table: "RoomAmenities",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
