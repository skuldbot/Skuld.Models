using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
    public partial class ThePlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ThePlace",
                table: "Modules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PlacePixelData",
                columns: table => new
                {
                    Id = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    XPos = table.Column<uint>(nullable: false),
                    YPos = table.Column<uint>(nullable: false),
                    R = table.Column<ushort>(nullable: false),
                    G = table.Column<ushort>(nullable: false),
                    B = table.Column<ushort>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacePixelData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacePixelHistory",
                columns: table => new
                {
                    EntryId = table.Column<ulong>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PixelId = table.Column<ulong>(nullable: false),
                    ModifierId = table.Column<ulong>(nullable: false),
                    Colour = table.Column<ulong>(nullable: false),
                    CostToChange = table.Column<ulong>(nullable: false),
                    ChangedTimestamp = table.Column<ulong>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacePixelHistory", x => x.EntryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlacePixelData");

            migrationBuilder.DropTable(
                name: "PlacePixelHistory");

            migrationBuilder.DropColumn(
                name: "ThePlace",
                table: "Modules");
        }
    }
}
