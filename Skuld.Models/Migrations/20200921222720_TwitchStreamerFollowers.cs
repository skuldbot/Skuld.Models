using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class TwitchStreamerFollowers : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "TwitchFollows",
				columns: table => new
				{
					Id = table.Column<ulong>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					ChannelId = table.Column<ulong>(nullable: false),
					GuildId = table.Column<ulong>(nullable: false),
					Streamer = table.Column<string>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TwitchFollows", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "TwitchFollows");
		}
	}
}
