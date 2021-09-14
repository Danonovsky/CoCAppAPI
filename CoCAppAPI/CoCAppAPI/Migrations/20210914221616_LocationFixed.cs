using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoCAppAPI.Migrations
{
    public partial class LocationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Locations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GameId",
                table: "Locations",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Games_GameId",
                table: "Locations",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Games_GameId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_GameId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Locations");
        }
    }
}
