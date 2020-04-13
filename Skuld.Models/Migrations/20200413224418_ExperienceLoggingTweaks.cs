using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class ExperienceLoggingTweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "MessagesSent",
                table: "UserXp",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "TimeInVoiceM",
                table: "UserXp",
                nullable: false,
                defaultValue: 0ul);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessagesSent",
                table: "UserXp");

            migrationBuilder.DropColumn(
                name: "TimeInVoiceM",
                table: "UserXp");
        }
    }
}
