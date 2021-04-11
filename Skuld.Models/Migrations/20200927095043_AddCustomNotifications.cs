#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddCustomNotifications : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "NewTweetMessage",
				table: "Guilds",
				nullable: true);

			migrationBuilder.AddColumn<string>(
				name: "TwitchLiveMessage",
				table: "Guilds",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "NewTweetMessage",
				table: "Guilds");

			migrationBuilder.DropColumn(
				name: "TwitchLiveMessage",
				table: "Guilds");
		}
	}
}
#pragma warning restore CA1062