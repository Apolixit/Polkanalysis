using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class CrowdloanModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventCrowdloanContributed",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    BlockId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    ModuleName = table.Column<string>(type: "text", nullable: false),
                    ModuleEvent = table.Column<string>(type: "text", nullable: false),
                    Account = table.Column<string>(type: "text", nullable: false),
                    CrowdloanId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCrowdloanContributed", x => new { x.BlockchainName, x.BlockId, x.EventId, x.ModuleName, x.ModuleEvent, x.Account, x.CrowdloanId, x.Amount });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCrowdloanContributed");
        }
    }
}
