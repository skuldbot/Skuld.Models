#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddGamblingModule : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "Gambling",
				table: "Modules",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "AutoAssign",
				table: "LevelRewards",
				nullable: false,
				defaultValue: false);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Gambling",
				table: "Modules");

			migrationBuilder.DropColumn(
				name: "AutoAssign",
				table: "LevelRewards");
		}
	}
}
#pragma warning restore CA1062