using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class VersionsController : MasterController
    {
        public VersionsController(IMediator mediator, ILogger<VersionsController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("pallets/{palletName}")]
        [Produces(typeof(IEnumerable<PalletVersionDto>))]
        [Description("Get all pallet versions for given pallet")]
        public async Task<ActionResult<IEnumerable<PalletVersionDto>>> GetPalletVersionsAsync(string palletName)
        {
            Guard.Against.NullOrEmpty(palletName, nameof(palletName));

            return await SendAndHandleResponseAsync(new PalletVersionsQuery() { PalletName = palletName });
        }

        [HttpGet("specversions")]
        [Produces(typeof(IEnumerable<SpecVersionDto>))]
        [Description("Get all spec versions for Polkadot")]
        public async Task<ActionResult<IEnumerable<SpecVersionDto>>> GetSpecVersionAsync()
        {
            return await SendAndHandleResponseAsync(new SpecVersionsQuery() { BlockchainName = "Polkadot" });
        }

        [HttpGet("specversion/{id}")]
        [Produces(typeof(IEnumerable<SpecVersionDto>))]
        [Description("Get spec version information for Polkadot")]
        public async Task<ActionResult<IEnumerable<SpecVersionDto>>> GetSpecVersionAsync(uint id)
        {
            return await SendAndHandleResponseAsync(new SpecVersionsQuery() { SpecVersionNumber = id, BlockchainName = "Polkadot" });
        }

        [HttpGet("specversion/{sourceVersion}/{targetVersion}")]
        [Produces(typeof(CompareSpecVersionDto))]
        [Description("Compare spec version given their version number")]
        public async Task<ActionResult<CompareSpecVersionDto>> CompareSpecVersionByNumberVersionAsync(uint sourceVersion, uint targetVersion)
        {
            return await SendAndHandleResponseAsync(CompareSpecVersionsQuery.FromSpecVersions(sourceVersion, targetVersion));
        }

        [HttpGet("specversion/{blockStart}/{blockEnd}")]
        [Produces(typeof(CompareSpecVersionDto))]
        [Description("Compare spec version given associated to their block number")]
        public async Task<ActionResult<CompareSpecVersionDto>> CompareSpecVersionByBlockNumberAsync(uint blockStart, uint blockEnd)
        {
            return await SendAndHandleResponseAsync(CompareSpecVersionsQuery.FromBlockNumber(blockStart, blockEnd));
        }

        [HttpGet("specversion/{blockStartHash}/{blockEndHash}")]
        [Produces(typeof(CompareSpecVersionDto))]
        [Description("Compare spec version given associated to their block hash")]
        public async Task<ActionResult<CompareSpecVersionDto>> CompareSpecVersionByBlockHashAsync(string blockStartHash, string blockEndHash)
        {
            return await SendAndHandleResponseAsync(CompareSpecVersionsQuery.FromBlockHash(blockStartHash, blockEndHash));
        }
    }
}
