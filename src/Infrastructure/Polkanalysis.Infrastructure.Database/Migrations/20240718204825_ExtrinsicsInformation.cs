using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class ExtrinsicsInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventManagerModel",
                table: "EventManagerModel");

            migrationBuilder.RenameTable(
                name: "EventManagerModel",
                newName: "EventManager");

            migrationBuilder.AddColumn<string>(
                name: "Justification",
                table: "BlockInformation",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventManager",
                table: "EventManager",
                columns: new[] { "BlockchainName", "ModuleName", "ModuleEvent" });

            migrationBuilder.CreateTable(
                name: "EraLifetime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsImmortal = table.Column<bool>(type: "boolean", nullable: false),
                    StartBlock = table.Column<long>(type: "bigint", nullable: true),
                    EndBlock = table.Column<long>(type: "bigint", nullable: true),
                    BlockchainName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EraLifetime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubstrateErrors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockNumber = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TypeError = table.Column<int>(type: "integer", nullable: false),
                    ElementId = table.Column<long>(type: "bigint", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    BlockchainName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstrateErrors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtrinsicsInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlockNumber = table.Column<long>(type: "bigint", nullable: false),
                    ExtrinsicIndex = table.Column<long>(type: "bigint", nullable: false),
                    BlockDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LifetimeId = table.Column<long>(type: "bigint", nullable: true),
                    Method = table.Column<string>(type: "text", nullable: false),
                    Event = table.Column<string>(type: "text", nullable: false),
                    AccountAddress = table.Column<string>(type: "text", nullable: true),
                    Charge = table.Column<double>(type: "double precision", nullable: true),
                    IsSigned = table.Column<bool>(type: "boolean", nullable: false),
                    Signature = table.Column<string>(type: "text", nullable: true),
                    TransactionVersion = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    StatusMessage = table.Column<string>(type: "text", nullable: false),
                    Fees = table.Column<double>(type: "double precision", nullable: true),
                    BlockchainName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtrinsicsInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtrinsicsInformation_EraLifetime_LifetimeId",
                        column: x => x.LifetimeId,
                        principalTable: "EraLifetime",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtrinsicsInformation_LifetimeId",
                table: "ExtrinsicsInformation",
                column: "LifetimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtrinsicsInformation");

            migrationBuilder.DropTable(
                name: "SubstrateErrors");

            migrationBuilder.DropTable(
                name: "EraLifetime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventManager",
                table: "EventManager");

            migrationBuilder.DropColumn(
                name: "Justification",
                table: "BlockInformation");

            migrationBuilder.RenameTable(
                name: "EventManager",
                newName: "EventManagerModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventManagerModel",
                table: "EventManagerModel",
                columns: new[] { "BlockchainName", "ModuleName", "ModuleEvent" });
        }
    }
}
