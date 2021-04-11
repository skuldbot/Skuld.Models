#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddPersistentRoles : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "PersistentRoles",
				columns: table => new
				{
					Id = table.Column<ulong>(nullable: false)
						.Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
					GuildId = table.Column<ulong>(nullable: false),
					RoleId = table.Column<ulong>(nullable: false),
					UserId = table.Column<ulong>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PersistentRoles", x => x.Id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "PersistentRoles");
		}
	}
}
#pragma warning restore CA1062