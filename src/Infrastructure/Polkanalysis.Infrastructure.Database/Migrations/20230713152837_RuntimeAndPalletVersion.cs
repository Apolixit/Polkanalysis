using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class RuntimeAndPalletVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PalletVersionModels",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    PalletName = table.Column<string>(type: "text", nullable: false),
                    PalletVersion = table.Column<int>(type: "integer", nullable: false),
                    PalletId = table.Column<int>(type: "integer", nullable: false),
                    BlockStart = table.Column<long>(type: "bigint", nullable: false),
                    BlockEnd = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletVersionModels", x => new { x.BlockchainName, x.PalletName, x.PalletVersion });
                });

            migrationBuilder.CreateTable(
                name: "SpecVersionModels",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    SpecVersion = table.Column<long>(type: "bigint", nullable: false),
                    BlockStart = table.Column<long>(type: "bigint", nullable: false),
                    BlockEnd = table.Column<long>(type: "bigint", nullable: true),
                    Metadata = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecVersionModels", x => new { x.BlockchainName, x.SpecVersion });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalletVersionModels");

            migrationBuilder.DropTable(
                name: "SpecVersionModels");
        }
    }
}
