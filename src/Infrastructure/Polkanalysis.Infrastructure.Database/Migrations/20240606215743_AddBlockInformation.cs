using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventSystemNewAccount",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventSystemKilledAccount",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventIdentityIdentitySet",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventIdentityIdentityKilled",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventIdentityIdentityCleared",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventCrowdloanContributed",
                newName: "AccountAddess");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventBalancesUnreserved",
                newName: "AccountAddess");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventBalancesSlashed",
                newName: "AccountAddess");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventBalancesReserved",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventBalancesEndowed",
                newName: "AccountAddress");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "EventBalancesDustLost",
                newName: "AccountAddress");

            migrationBuilder.CreateTable(
                name: "BlockInformation",
                columns: table => new
                {
                    BlockNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockHash = table.Column<string>(type: "text", nullable: false),
                    ValidatorAddress = table.Column<string>(type: "text", nullable: false),
                    EventsCount = table.Column<long>(type: "bigint", nullable: false),
                    ExtrinsicsCount = table.Column<long>(type: "bigint", nullable: false),
                    LogsCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockInformation", x => x.BlockNumber);
                });

            migrationBuilder.CreateTable(
                name: "EventAuctionsAuctionClosed",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    AuctionIndex = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAuctionsAuctionClosed", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.AuctionIndex });
                });

            migrationBuilder.CreateTable(
                name: "EventAuctionsAuctionStarted",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    AuctionIndex = table.Column<long>(type: "bigint", nullable: false),
                    LeasePeriod = table.Column<long>(type: "bigint", nullable: false),
                    Ending = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAuctionsAuctionStarted", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.AuctionIndex, x.LeasePeriod, x.Ending });
                });

            migrationBuilder.CreateTable(
                name: "EventCrowdloanCreated",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    CrowdloanId = table.Column<int>(type: "integer", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCrowdloanCreated", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.CrowdloanId });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockInformation");

            migrationBuilder.DropTable(
                name: "EventAuctionsAuctionClosed");

            migrationBuilder.DropTable(
                name: "EventAuctionsAuctionStarted");

            migrationBuilder.DropTable(
                name: "EventCrowdloanCreated");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventSystemNewAccount",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventSystemKilledAccount",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventIdentityIdentitySet",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventIdentityIdentityKilled",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventIdentityIdentityCleared",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddess",
                table: "EventCrowdloanContributed",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddess",
                table: "EventBalancesUnreserved",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddess",
                table: "EventBalancesSlashed",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventBalancesReserved",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventBalancesEndowed",
                newName: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountAddress",
                table: "EventBalancesDustLost",
                newName: "Account");
        }
    }
}
