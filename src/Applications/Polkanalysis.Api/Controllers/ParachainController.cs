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

        /// <summary>
        /// Return all winner parachains
        /// </summary>
        /// <returns>List of parachain informations</returns>
        [HttpGet]
        [Produces(typeof(IEnumerable<ParachainLightDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return all winner parachains")]
        public async Task<ActionResult<IEnumerable<ParachainLightDto>>> GetParachainsAsync()
        {
            return await SendAndHandleResponseAsync(new ParachainsQuery());
        }

        /// <summary>
        /// Retrieve a parachain by it Id
        /// </summary>
        /// <param name="parachainId"></param>
        /// <returns>Parachain details</returns>
        [HttpGet("{parachainId}")]
        [Produces(typeof(ParachainDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Retrieve a parachain by it Id")]
        public async Task<ActionResult<ParachainDto>> GetParachainAsync(uint parachainId)
        {
            return await SendAndHandleResponseAsync(new ParachainDetailQuery() { ParachainId = parachainId });
        }

        /// <summary>
        /// Return all crowdloans
        /// </summary>
        /// <returns>List of crowdloans information</returns>
        [HttpGet("crowdloans")]
        [Produces(typeof(IEnumerable<CrowdloanLightDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return all crowdloans")]
        public async Task<ActionResult<IEnumerable<CrowdloanLightDto>>> GetCrowdloansAsync()
        {
            return await SendAndHandleResponseAsync(new CrowdloansQuery());
        }

        /// <summary>
        /// Retrieve a crowdloan by it Id
        /// </summary>
        /// <param name="crowndloanId"></param>
        /// <returns>Crowdloan details</returns>
        [HttpGet("crowdloans/{crowndloanId}")]
        [Produces(typeof(CrowdloanDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Retrieve a crowdloan by it Id")]
        public async Task<ActionResult<CrowdloanDto>> GetCrowdloanAsync(uint crowndloanId)
        {
            return await SendAndHandleResponseAsync(new CrowdloanDetailQuery() { CrowndloanId = crowndloanId });
        }

        /// <summary>
        /// Return all auctions
        /// </summary>
        /// <returns>List of Auctions information</returns>
        [HttpGet("auctions")]
        [Produces(typeof(IEnumerable<AuctionLightDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return all auctions")]
        public async Task<ActionResult<IEnumerable<AuctionLightDto>>> GetAuctionsAsync()
        {
            return await SendAndHandleResponseAsync(new AuctionsQuery());
        }

        /// <summary>
        /// Retrieve an auction by it Id
        /// </summary>
        /// <param name="auctionId"></param>
        /// <returns>Auction information</returns>
        [HttpGet("auctions/{auctionId}")]
        [Produces(typeof(AuctionDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Retrieve an auction by it Id")]
        public async Task<ActionResult<AuctionDto>> GetAuctionAsync(uint auctionId)
        {
            return await SendAndHandleResponseAsync(new AuctionDetailQuery() { AuctionId = auctionId });
        }
    }
}
