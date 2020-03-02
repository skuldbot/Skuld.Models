using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Core.Models.Migrations
{
    public partial class UpdateReminders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "Created",
                table: "Reminders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Id",
                table: "Reminders",
                nullable: false,
                oldClrType: typeof(ushort),
                oldType: "smallint unsigned")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<ushort>(
                name: "LocalId",
                table: "Reminders",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Reminders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Reminders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(ulong));

            migrationBuilder.AlterColumn<ushort>(
                name: "Id",
                table: "Reminders",
                type: "smallint unsigned",
                nullable: false,
                oldClrType: typeof(ulong))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
