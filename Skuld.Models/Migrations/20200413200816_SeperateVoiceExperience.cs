using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class SeperateVoiceExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVoiceExperience",
                table: "UserXp",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoiceExperience",
                table: "UserXp");
        }
    }
}
