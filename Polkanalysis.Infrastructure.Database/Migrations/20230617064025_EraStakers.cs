using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    /// <inheritdoc />
    public partial class EraStakers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EraStakersModels",
                columns: table => new
                {
                    BlockchainName = table.Column<string>(type: "text", nullable: false),
                    EraStakersId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EraId = table.Column<int>(type: "integer", nullable: false),
                    ValidatorAddress = table.Column<string>(type: "text", nullable: false),
                    TotalStake = table.Column<BigInteger>(type: "numeric", nullable: false),
                    OwnStake = table.Column<BigInteger>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EraStakersModels", x => new { x.EraStakersId, x.BlockchainName, x.EraId, x.ValidatorAddress });
                    table.UniqueConstraint("AK_EraStakersModels_EraStakersId", x => x.EraStakersId);
                });

            migrationBuilder.CreateTable(
                name: "EraStakersNominatorsModel",
                columns: table => new
                {
                    NominatorAddress = table.Column<string>(type: "text", nullable: false),
                    EraStakersId = table.Column<int>(type: "integer", nullable: false),
                    ValueStake = table.Column<BigInteger>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EraStakersNominatorsModel", x => new { x.EraStakersId, x.NominatorAddress });
                    table.ForeignKey(
                        name: "FK_EraStakersNominatorsModel_EraStakersModels_EraStakersId",
                        column: x => x.EraStakersId,
                        principalTable: "EraStakersModels",
                        principalColumn: "EraStakersId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EraStakersNominatorsModel");

            migrationBuilder.DropTable(
                name: "EraStakersModels");
        }
    }
}
