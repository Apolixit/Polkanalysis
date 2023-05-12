using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;

namespace Polkanalysis.Api.Controllers
{
    public class CrowdloanController : MasterController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CrowdloanController> _logger;

        public CrowdloanController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCrowdloansAsync()
        {
            var result = await _mediator.Send(new CrowdloanListQuery(), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("{crowndloanId}")]
        public async Task<IActionResult> GetCrowdloanAsync(uint crowndloanId)
        {
            var result = await _mediator.Send(new CrowdloanQuery() { CrowndloanId = crowndloanId }, CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }
    }
}
