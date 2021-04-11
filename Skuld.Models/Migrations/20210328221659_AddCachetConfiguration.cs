#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddCachetConfiguration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Shards",
				table: "Configurations");

			migrationBuilder.AddColumn<string>(
				name: "CachetBase",
				table: "Configurations",
				type: "longtext CHARACTER SET utf8mb4",
				nullable: true);

			migrationBuilder.AddColumn<int>(
				name: "CachetShardGroup",
				table: "Configurations",
				type: "int",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.AddColumn<string>(
				name: "CachetToken",
				table: "Configurations",
				type: "longtext CHARACTER SET utf8mb4",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "CachetBase",
				table: "Configurations");

			migrationBuilder.DropColumn(
				name: "CachetShardGroup",
				table: "Configurations");

			migrationBuilder.DropColumn(
				name: "CachetToken",
				table: "Configurations");

			migrationBuilder.AddColumn<ushort>(
				name: "Shards",
				table: "Configurations",
				type: "smallint unsigned",
				nullable: false,
				defaultValue: (ushort)0);
		}
	}
}
#pragma warning restore CA1062