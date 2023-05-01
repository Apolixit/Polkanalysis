using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabaseWithBasicEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventBalancesBalanceSet",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    RootAccount = table.Column<string>(type: "text", nullable: false),
                    Amount1 = table.Column<double>(type: "double precision", nullable: false),
                    Amount2 = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesBalanceSet", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.RootAccount, x.Amount1, x.Amount2 });
                });

            migrationBuilder.CreateTable(
                name: "EventBalancesDustLost",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesDustLost", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventBalancesEndowed",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesEndowed", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventBalancesReserved",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    ReservedAmount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesReserved", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.ReservedAmount });
                });

            migrationBuilder.CreateTable(
                name: "EventBalancesSlashed",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesSlashed", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventBalancesTransfer",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    From = table.Column<string>(type: "text", nullable: false),
                    To = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesTransfer", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.From, x.To, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventBalancesUnreserved",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    UnreservedAmount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBalancesUnreserved", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.UnreservedAmount });
                });

            migrationBuilder.CreateTable(
                name: "EventIdentityIdentityCleared",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIdentityIdentityCleared", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventIdentityIdentityKilled",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIdentityIdentityKilled", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.Amount });
                });

            migrationBuilder.CreateTable(
                name: "EventIdentityIdentitySet",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventIdentityIdentitySet", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account });
                });

            migrationBuilder.CreateTable(
                name: "EventSystemKilledAccount",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSystemKilledAccount", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account });
                });

            migrationBuilder.CreateTable(
                name: "EventSystemNewAccount",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSystemNewAccount", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventBalancesBalanceSet");

            migrationBuilder.DropTable(
                name: "EventBalancesDustLost");

            migrationBuilder.DropTable(
                name: "EventBalancesEndowed");

            migrationBuilder.DropTable(
                name: "EventBalancesReserved");

            migrationBuilder.DropTable(
                name: "EventBalancesSlashed");

            migrationBuilder.DropTable(
                name: "EventBalancesTransfer");

            migrationBuilder.DropTable(
                name: "EventBalancesUnreserved");

            migrationBuilder.DropTable(
                name: "EventIdentityIdentityCleared");

            migrationBuilder.DropTable(
                name: "EventIdentityIdentityKilled");

            migrationBuilder.DropTable(
                name: "EventIdentityIdentitySet");

            migrationBuilder.DropTable(
                name: "EventSystemKilledAccount");

            migrationBuilder.DropTable(
                name: "EventSystemNewAccount");
        }
    }
}
