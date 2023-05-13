using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
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
        public async Task<IActionResult> GetParachainsAsync()
        {
            return await SendAndHandleResponseAsync(new ParachainsQuery());
        }

        [HttpGet("{parachainId}")]
        [Produces(typeof(ParachainDto))]
        public async Task<IActionResult> GetParachainAsync(uint parachainId)
        {
            return await SendAndHandleResponseAsync(new ParachainDetailQuery() { ParachainId = parachainId });
        }
    }
}
