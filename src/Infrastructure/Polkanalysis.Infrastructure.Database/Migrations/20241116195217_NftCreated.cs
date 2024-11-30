using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class NftCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EraStakersNominatorsModel_EraStakersModels_EraStakersId",
                table: "EraStakersNominatorsModel");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_EraStakersModels_EraStakersId",
                table: "EraStakersModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EraStakersModels",
                table: "EraStakersModels");

            migrationBuilder.DropColumn(
                name: "EraStakersId",
                table: "EraStakersModels");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_EraStakersModels_Id",
                table: "EraStakersModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EraStakersModels",
                table: "EraStakersModels",
                columns: new[] { "BlockchainName", "EraId", "ValidatorAddress" });

            migrationBuilder.CreateTable(
                name: "EventNftsCreated",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Collection = table.Column<double>(type: "double precision", nullable: false),
                    Creator = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNftsCreated", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Collection, x.Creator, x.Owner });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EraStakersNominatorsModel_EraStakersModels_EraStakersId",
                table: "EraStakersNominatorsModel",
                column: "EraStakersId",
                principalTable: "EraStakersModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EraStakersNominatorsModel_EraStakersModels_EraStakersId",
                table: "EraStakersNominatorsModel");

            migrationBuilder.DropTable(
                name: "EventNftsCreated");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_EraStakersModels_Id",
                table: "EraStakersModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EraStakersModels",
                table: "EraStakersModels");

            migrationBuilder.AddColumn<int>(
                name: "EraStakersId",
                table: "EraStakersModels",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_EraStakersModels_EraStakersId",
                table: "EraStakersModels",
                column: "EraStakersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EraStakersModels",
                table: "EraStakersModels",
                columns: new[] { "EraStakersId", "BlockchainName", "EraId", "ValidatorAddress" });

            migrationBuilder.AddForeignKey(
                name: "FK_EraStakersNominatorsModel_EraStakersModels_EraStakersId",
                table: "EraStakersNominatorsModel",
                column: "EraStakersId",
                principalTable: "EraStakersModels",
                principalColumn: "EraStakersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
