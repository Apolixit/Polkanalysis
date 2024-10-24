using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddEventsAndExtrinsicJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Parameters",
                table: "SubstrateErrors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BlockEndDateTime",
                table: "SpecVersionModels",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BlockStartDateTime",
                table: "SpecVersionModels",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Parameters",
                table: "ExtrinsicsInformation",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "SubstrateErrors");

            migrationBuilder.DropColumn(
                name: "BlockEndDateTime",
                table: "SpecVersionModels");

            migrationBuilder.DropColumn(
                name: "BlockStartDateTime",
                table: "SpecVersionModels");

            migrationBuilder.DropColumn(
                name: "Parameters",
                table: "ExtrinsicsInformation");
        }
    }
}
