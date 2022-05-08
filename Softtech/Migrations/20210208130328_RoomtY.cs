using Microsoft.EntityFrameworkCore.Migrations;

namespace Softtech.Migrations
{
    public partial class RoomtY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoomTypeId",
                table: "TblRooms",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TblInspections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TblRooms_RoomTypeId",
                table: "TblRooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblInspections_ApplicationUserId",
                table: "TblInspections",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblInspections_AspNetUsers_ApplicationUserId",
                table: "TblInspections",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TblRooms_TblRoomTypes_RoomTypeId",
                table: "TblRooms",
                column: "RoomTypeId",
                principalTable: "TblRoomTypes",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblInspections_AspNetUsers_ApplicationUserId",
                table: "TblInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRooms_TblRoomTypes_RoomTypeId",
                table: "TblRooms");

            migrationBuilder.DropIndex(
                name: "IX_TblRooms_RoomTypeId",
                table: "TblRooms");

            migrationBuilder.DropIndex(
                name: "IX_TblInspections_ApplicationUserId",
                table: "TblInspections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TblInspections");

            migrationBuilder.AlterColumn<string>(
                name: "RoomTypeId",
                table: "TblRooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }
    }
}
