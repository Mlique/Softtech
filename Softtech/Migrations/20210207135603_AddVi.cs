using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softtech.Migrations
{
    public partial class AddVi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisiteeName",
                table: "TblVisitors");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TblVisitors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RoomId",
                table: "TblVisitors",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TblVisitors_RoomId",
                table: "TblVisitors",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblVisitors_TblRooms_RoomId",
                table: "TblVisitors",
                column: "RoomId",
                principalTable: "TblRooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblVisitors_TblRooms_RoomId",
                table: "TblVisitors");

            migrationBuilder.DropIndex(
                name: "IX_TblVisitors_RoomId",
                table: "TblVisitors");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TblVisitors");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "TblVisitors");

            migrationBuilder.AddColumn<string>(
                name: "VisiteeName",
                table: "TblVisitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
