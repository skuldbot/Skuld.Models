using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class RemoveVoiceExperienceBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoiceExperience",
                table: "UserXp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVoiceExperience",
                table: "UserXp",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
