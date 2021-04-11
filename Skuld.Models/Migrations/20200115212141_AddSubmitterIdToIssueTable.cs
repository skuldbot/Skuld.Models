﻿#pragma warning disable CA1062
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skuld.Models.Migrations
{
	public partial class AddSubmitterIdToIssueTable : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<ulong>(
				name: "SubmitterId",
				table: "Issues",
				nullable: false,
				defaultValue: 0ul);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "SubmitterId",
				table: "Issues");
		}
	}
}
#pragma warning restore CA1062