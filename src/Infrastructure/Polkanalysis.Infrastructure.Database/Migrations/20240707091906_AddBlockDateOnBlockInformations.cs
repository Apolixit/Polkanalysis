using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockDateOnBlockInformations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BlockDate",
                table: "BlockInformation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlockDate",
                table: "BlockInformation");
        }
    }
}
