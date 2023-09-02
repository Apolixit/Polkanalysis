using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain.Auction;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class ParachainController : MasterController
    {
        public ParachainController(IMediator mediator, ILogger<ParachainController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<ParachainLightDto>))]
        [Description("Return all winner parachains")]
        public async Task<ActionResult<IEnumerable<ParachainLightDto>>> GetParachainsAsync()
        {
            return await SendAndHandleResponseAsync(new ParachainsQuery());
        }

        [HttpGet("{parachainId}")]
        [Produces(typeof(ParachainDto))]
        [Description("Retrieve a parachain by it Id")]
        public async Task<ActionResult<ParachainDto>> GetParachainAsync(uint parachainId)
        {
            return await SendAndHandleResponseAsync(new ParachainDetailQuery() { ParachainId = parachainId });
        }

        [HttpGet("crowdloans")]
        [Produces(typeof(IEnumerable<CrowdloanLightDto>))]
        [Description("Return all crowdloans")]
        public async Task<ActionResult<IEnumerable<CrowdloanLightDto>>> GetCrowdloansAsync()
        {
            return await SendAndHandleResponseAsync(new CrowdloansQuery());
        }

        [HttpGet("crowdloans/{crowndloanId}")]
        [Produces(typeof(CrowdloanDto))]
        [Description("Retrieve a crowdloan by it Id")]
        public async Task<ActionResult<CrowdloanDto>> GetCrowdloanAsync(uint crowndloanId)
        {
            return await SendAndHandleResponseAsync(new CrowdloanDetailQuery() { CrowndloanId = crowndloanId });
        }

        [HttpGet("auctions")]
        [Produces(typeof(IEnumerable<AuctionLightDto>))]
        [Description("Return all auctions")]
        public async Task<ActionResult<IEnumerable<AuctionLightDto>>> GetAuctionsAsync()
        {
            return await SendAndHandleResponseAsync(new AuctionsQuery());
        }

        [HttpGet("auctions/{auctionId}")]
        [Produces(typeof(AuctionDto))]
        [Description("Retrieve an auction by it Id")]
        public async Task<ActionResult<AuctionDto>> GetAuctionAsync(uint auctionId)
        {
            return await SendAndHandleResponseAsync(new AuctionDetailQuery() { AuctionId = auctionId });
        }
    }
}
