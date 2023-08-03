using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddMetadataVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PalletId",
                table: "PalletVersionModels");

            migrationBuilder.AddColumn<long>(
                name: "MetadataVersion",
                table: "SpecVersionModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SpecVersion",
                table: "PalletVersionModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetadataVersion",
                table: "SpecVersionModels");

            migrationBuilder.DropColumn(
                name: "SpecVersion",
                table: "PalletVersionModels");

            migrationBuilder.AddColumn<int>(
                name: "PalletId",
                table: "PalletVersionModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
