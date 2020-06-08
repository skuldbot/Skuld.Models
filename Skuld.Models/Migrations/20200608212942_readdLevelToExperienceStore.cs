using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class readdLevelToExperienceStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "Level",
                table: "UserXp",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "UserXp");
        }
    }
}
