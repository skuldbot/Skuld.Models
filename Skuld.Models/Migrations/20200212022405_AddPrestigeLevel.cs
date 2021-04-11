#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddPrestigeLevel : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<ulong>(
				name: "PrestigeLevel",
				table: "Users",
				nullable: false,
				defaultValue: 0ul);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PrestigeLevel",
				table: "Users");
		}
	}
}
#pragma warning restore CA1062