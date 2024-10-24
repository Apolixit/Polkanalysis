using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEventsInformationPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsInformation",
                table: "EventsInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsInformation",
                table: "EventsInformation",
                columns: new[] { "BlockchainName", "BlockId", "EventId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventsInformation",
                table: "EventsInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventsInformation",
                table: "EventsInformation",
                columns: new[] { "BlockchainName", "ModuleName", "ModuleEvent" });
        }
    }
}
