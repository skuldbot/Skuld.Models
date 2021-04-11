#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddStarboardBlackWhiteList : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "StarboardConfigurable",
				columns: table => new
				{
					Id = table.Column<ulong>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					GuildId = table.Column<ulong>(nullable: false),
					TargetId = table.Column<ulong>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_StarboardConfigurable", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "StarboardConfigurable");
		}
	}
}
#pragma warning restore CA1062