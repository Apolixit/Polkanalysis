using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Parachain;

namespace Polkanalysis.Api.Controllers
{
    public class ParachainController : MasterController
    {
        private readonly ILogger<ParachainController> _logger;

        public ParachainController(IMediator mediator, ILogger<ParachainController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<ParachainLightDto>))]
        public async Task<ActionResult<IEnumerable<ParachainLightDto>>> GetParachainsAsync()
        {
            return await SendAndHandleResponseAsync(new ParachainsQuery());
        }

        [HttpGet("{parachainId}")]
        [Produces(typeof(ParachainDto))]
        public async Task<ActionResult<ParachainDto>> GetParachainAsync(uint parachainId)
        {
            return await SendAndHandleResponseAsync(new ParachainDetailQuery() { ParachainId = parachainId });
        }

        [HttpGet("crowdloans")]
        [Produces(typeof(IEnumerable<CrowdloanListDto>))]
        public async Task<ActionResult<IEnumerable<CrowdloanListDto>>> GetCrowdloansAsync()
        {
            return await SendAndHandleResponseAsync(new CrowdloanListQuery());
        }

        [HttpGet("crowdloans/{crowndloanId}")]
        [Produces(typeof(CrowdloanDto))]
        public async Task<ActionResult<CrowdloanDto>> GetCrowdloanAsync(uint crowndloanId)
        {
            return await SendAndHandleResponseAsync(new CrowdloanQuery() { CrowndloanId = crowndloanId });
        }
    }
}
