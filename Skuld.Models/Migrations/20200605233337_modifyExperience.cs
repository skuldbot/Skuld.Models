using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class modifyExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "UserXp");

            migrationBuilder.DropColumn(
                name: "XP",
                table: "UserXp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "Level",
                table: "UserXp",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "XP",
                table: "UserXp",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul);
        }
    }
}
