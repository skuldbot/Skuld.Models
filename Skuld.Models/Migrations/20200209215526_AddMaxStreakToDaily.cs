#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddMaxStreakToDaily : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Description",
				table: "Users");

			migrationBuilder.AddColumn<uint>(
				name: "Streak",
				table: "Users",
				nullable: false,
				defaultValue: 0u);

			migrationBuilder.AddColumn<ulong>(
				name: "MaxStreak",
				table: "Configurations",
				nullable: false,
				defaultValue: 0ul);

			migrationBuilder.AddColumn<ulong>(
				name: "StreakLimitDays",
				table: "Configurations",
				nullable: false,
				defaultValue: 0ul);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Streak",
				table: "Users");

			migrationBuilder.DropColumn(
				name: "MaxStreak",
				table: "Configurations");

			migrationBuilder.DropColumn(
				name: "StreakLimitDays",
				table: "Configurations");

			migrationBuilder.AddColumn<string>(
				name: "Description",
				table: "Users",
				type: "longtext CHARACTER SET utf8mb4",
				nullable: true);
		}
	}
}
#pragma warning restore CA1062