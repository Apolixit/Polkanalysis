using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddEvents_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventSystemNewAccount",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventSystemNewAccount",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventSystemKilledAccount",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventSystemKilledAccount",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventIdentityIdentitySet",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventIdentityIdentitySet",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventIdentityIdentityKilled",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventIdentityIdentityKilled",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventIdentityIdentityCleared",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventIdentityIdentityCleared",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "CrowdloanId",
                table: "EventCrowdloanCreated",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventCrowdloanCreated",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventCrowdloanCreated",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "CrowdloanId",
                table: "EventCrowdloanContributed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventCrowdloanContributed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventCrowdloanContributed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesUnreserved",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesUnreserved",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesTransfer",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesTransfer",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesSlashed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesSlashed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesReserved",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesReserved",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesEndowed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesEndowed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesDustLost",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesDustLost",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventBalancesBalanceSet",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventBalancesBalanceSet",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventAuctionsAuctionStarted",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventAuctionsAuctionStarted",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "EventId",
                table: "EventAuctionsAuctionClosed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlockId",
                table: "EventAuctionsAuctionClosed",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "EventManagerModel",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    LastOccurenceScannedBlockId = table.Column<int>(type: "integer", nullable: false),
                    LastScanBlockId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventManagerModel", x => new { x.BlockchainName, x.ModuleName, x.ModuleEvent });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsBonded",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Member = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Bonded = table.Column<double>(type: "double precision", nullable: false),
                    Joined = table.Column<bool>(type: "boolean", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsBonded", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Member, x.Pool_id, x.Bonded, x.Joined });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsCreated",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Depositor = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsCreated", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Depositor, x.Pool_id });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsDestroyed",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsDestroyed", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Pool_id });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsMemberRemoved",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Member = table.Column<string>(type: "text", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsMemberRemoved", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Pool_id, x.Member });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsMinBalanceDeficitAdjusted",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsMinBalanceDeficitAdjusted", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Pool_id, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsMinBalanceExcessAdjusted",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsMinBalanceExcessAdjusted", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Pool_id, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsPaidOut",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Member = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Payout = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsPaidOut", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Member, x.Pool_id, x.Payout });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsPoolCommissionClaimed",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Commission = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsPoolCommissionClaimed", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Pool_id, x.Commission });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsUnbonded",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Member = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    Points = table.Column<double>(type: "double precision", nullable: false),
                    Era = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsUnbonded", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Member, x.Pool_id, x.Balance, x.Points, x.Era });
                });

            migrationBuilder.CreateTable(
                name: "EventNominationPoolsWithdrawn",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Member = table.Column<string>(type: "text", nullable: false),
                    Pool_id = table.Column<long>(type: "bigint", nullable: false),
                    Balance = table.Column<double>(type: "double precision", nullable: false),
                    Points = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventNominationPoolsWithdrawn", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Member, x.Pool_id, x.Balance, x.Points });
                });

            migrationBuilder.CreateTable(
                name: "EventStakingEraPaid",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<long>(type: "bigint", nullable: false),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Era_index = table.Column<long>(type: "bigint", nullable: false),
                    Validator_payout = table.Column<double>(type: "double precision", nullable: false),
                    Remainder = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStakingEraPaid", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Era_index, x.Validator_payout, x.Remainder });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventManagerModel");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsBonded");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsCreated");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsDestroyed");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsMemberRemoved");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsMinBalanceDeficitAdjusted");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsMinBalanceExcessAdjusted");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsPaidOut");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsPoolCommissionClaimed");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsUnbonded");

            migrationBuilder.DropTable(
                name: "EventNominationPoolsWithdrawn");

            migrationBuilder.DropTable(
                name: "EventStakingEraPaid");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventSystemNewAccount",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventSystemNewAccount",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventSystemKilledAccount",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventSystemKilledAccount",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventIdentityIdentitySet",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventIdentityIdentitySet",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventIdentityIdentityKilled",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventIdentityIdentityKilled",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventIdentityIdentityCleared",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventIdentityIdentityCleared",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CrowdloanId",
                table: "EventCrowdloanCreated",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventCrowdloanCreated",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventCrowdloanCreated",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "CrowdloanId",
                table: "EventCrowdloanContributed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventCrowdloanContributed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventCrowdloanContributed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesUnreserved",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesUnreserved",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesTransfer",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesTransfer",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesSlashed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesSlashed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesReserved",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesReserved",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesEndowed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesEndowed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesDustLost",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesDustLost",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBalancesBalanceSet",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventBalancesBalanceSet",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventAuctionsAuctionStarted",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventAuctionsAuctionStarted",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventAuctionsAuctionClosed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlockId",
                table: "EventAuctionsAuctionClosed",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
