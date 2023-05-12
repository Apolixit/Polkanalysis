using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Polkanalysis.Api.Controllers
{
    public class CrowdloanController
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
            throw new NotImplementedException();
        }

        [HttpGet("{crowndloanId}")]
        public async Task<IActionResult> GetCrowdloanAsync(int crowndloanId)
        {
            throw new NotImplementedException();
        }
    }
}
