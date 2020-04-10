using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class TweakStreaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxStreak",
                table: "Configurations");

            migrationBuilder.AddColumn<uint>(
                name: "MaxStreak",
                table: "Users",
                nullable: false,
                defaultValue: 0u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxStreak",
                table: "Users");

            migrationBuilder.AddColumn<ulong>(
                name: "MaxStreak",
                table: "Configurations",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);
        }
    }
}
