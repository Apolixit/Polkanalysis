using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddEventsInformations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Parameters",
                table: "ExtrinsicsInformation",
                newName: "JsonParameters");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TokenPrices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SubstrateErrors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SpecVersionModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PalletVersionModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventSystemNewAccount",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventSystemKilledAccount",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventStakingEraPaid",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsWithdrawn",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsUnbonded",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsPoolCommissionClaimed",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsPaidOut",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsMinBalanceExcessAdjusted",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsMinBalanceDeficitAdjusted",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsMemberRemoved",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsDestroyed",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsCreated",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventNominationPoolsBonded",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventManager",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventIdentityIdentitySet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventIdentityIdentityKilled",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventIdentityIdentityCleared",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventCrowdloanCreated",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventCrowdloanContributed",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesUnreserved",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesTransfer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesSlashed",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesReserved",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesEndowed",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesDustLost",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventBalancesBalanceSet",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventAuctionsAuctionStarted",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventAuctionsAuctionClosed",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EraStakersModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventsInformation",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    JsonParameters = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsInformation", x => new { x.BlockchainName, x.ModuleName, x.ModuleEvent });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsInformation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TokenPrices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SpecVersionModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PalletVersionModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventSystemNewAccount");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventSystemKilledAccount");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventStakingEraPaid");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsWithdrawn");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsUnbonded");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsPoolCommissionClaimed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsPaidOut");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsMinBalanceExcessAdjusted");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsMinBalanceDeficitAdjusted");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsMemberRemoved");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsDestroyed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsCreated");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventNominationPoolsBonded");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventManager");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventIdentityIdentitySet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventIdentityIdentityKilled");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventIdentityIdentityCleared");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventCrowdloanCreated");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventCrowdloanContributed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesUnreserved");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesTransfer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesSlashed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesReserved");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesEndowed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesDustLost");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventBalancesBalanceSet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventAuctionsAuctionStarted");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventAuctionsAuctionClosed");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EraStakersModels");

            migrationBuilder.RenameColumn(
                name: "JsonParameters",
                table: "ExtrinsicsInformation",
                newName: "Parameters");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "SubstrateErrors",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
