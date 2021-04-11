#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Skuld.Models.Migrations
{
	public partial class AddReminders : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<ulong>(
				name: "LevelRequired",
				table: "LevelRewards",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AlterColumn<ulong>(
				name: "Id",
				table: "LevelRewards",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
				.OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

			migrationBuilder.AlterColumn<ulong>(
				name: "Price",
				table: "IAmRoles",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AlterColumn<ulong>(
				name: "LevelRequired",
				table: "IAmRoles",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int");

			migrationBuilder.AlterColumn<ulong>(
				name: "Id",
				table: "IAmRoles",
				nullable: false,
				oldClrType: typeof(int),
				oldType: "int")
				.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
				.OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

			migrationBuilder.AddColumn<bool>(
				name: "StackingRoles",
				table: "Features",
				nullable: false,
				defaultValue: false);

			migrationBuilder.CreateTable(
				name: "Reminders",
				columns: table => new
				{
					Id = table.Column<ushort>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					UserId = table.Column<ulong>(nullable: false),
					ChannelId = table.Column<ulong>(nullable: false),
					Timeout = table.Column<ulong>(nullable: false),
					Content = table.Column<string>(nullable: true),
					MessageLink = table.Column<string>(nullable: true),
					Created = table.Column<DateTime>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Reminders", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Reminders");

			migrationBuilder.DropColumn(
				name: "StackingRoles",
				table: "Features");

			migrationBuilder.AlterColumn<int>(
				name: "LevelRequired",
				table: "LevelRewards",
				type: "int",
				nullable: false,
				oldClrType: typeof(ulong));

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "LevelRewards",
				type: "int",
				nullable: false,
				oldClrType: typeof(ulong))
				.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
				.OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

			migrationBuilder.AlterColumn<int>(
				name: "Price",
				table: "IAmRoles",
				type: "int",
				nullable: false,
				oldClrType: typeof(ulong));

			migrationBuilder.AlterColumn<int>(
				name: "LevelRequired",
				table: "IAmRoles",
				type: "int",
				nullable: false,
				oldClrType: typeof(ulong));

			migrationBuilder.AlterColumn<int>(
				name: "Id",
				table: "IAmRoles",
				type: "int",
				nullable: false,
				oldClrType: typeof(ulong))
				.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
				.OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
		}
	}
}
#pragma warning restore CA1062