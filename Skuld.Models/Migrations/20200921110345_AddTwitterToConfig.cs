using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class AddTwitterToConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TwitterAccessSec",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterAccessTok",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterConKey",
                table: "Configurations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterConSec",
                table: "Configurations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwitterAccessSec",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "TwitterAccessTok",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "TwitterConKey",
                table: "Configurations");

            migrationBuilder.DropColumn(
                name: "TwitterConSec",
                table: "Configurations");
        }
    }
}
