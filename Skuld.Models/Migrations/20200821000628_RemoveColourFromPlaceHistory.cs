using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class RemoveColourFromPlaceHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colour",
                table: "PlacePixelHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "Colour",
                table: "PlacePixelHistory",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);
        }
    }
}
