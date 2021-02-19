using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddStarboard : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "SelfStarring",
				table: "Guilds",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "StarDeleteIfSourceDelete",
				table: "Guilds",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<string>(
				name: "StarEmote",
				table: "Guilds",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "StarRange1",
				table: "Guilds",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "StarRange2",
				table: "Guilds",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "StarRange3",
				table: "Guilds",
				nullable: true);

			migrationBuilder.AddColumn<ushort>(
				name: "StarReactAmount",
				table: "Guilds",
				nullable: false,
				defaultValue: (ushort)0);

			migrationBuilder.AddColumn<ulong>(
				name: "StarboardChannel",
				table: "Guilds",
				nullable: false,
				defaultValue: 0ul);

			migrationBuilder.AddColumn<bool>(
				name: "Starboard",
				table: "Features",
				nullable: false,
				defaultValue: false);

			migrationBuilder.CreateTable(
				name: "GuildWeeklyPots",
				columns: table => new
				{
					Id = table.Column<ulong>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					GuildId = table.Column<ulong>(nullable: false),
					UserId = table.Column<ulong>(nullable: false),
					Amount = table.Column<ulong>(nullable: false),
					LastGranted = table.Column<ulong>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GuildWeeklyPots", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "StarboardVotes",
				columns: table => new
				{
					Id = table.Column<ulong>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					MessageId = table.Column<ulong>(nullable: false),
					StarboardMessageId = table.Column<ulong>(nullable: false),
					VoterId = table.Column<ulong>(nullable: false),
					MessageAuthorId = table.Column<ulong>(nullable: false),
					GuildId = table.Column<ulong>(nullable: false),
					ChannelId = table.Column<ulong>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StarboardVotes", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "GuildWeeklyPots");

			migrationBuilder.DropTable(
				name: "StarboardVotes");

			migrationBuilder.DropColumn(
				name: "SelfStarring",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarDeleteIfSourceDelete",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarEmote",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarRange1",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarRange2",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarRange3",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarReactAmount",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "StarboardChannel",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "Starboard",
				table: "Features");
		}
	}
}
