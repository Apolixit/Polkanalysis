using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Primary.Statistics.Account;
using Polkanalysis.Domain.Contracts.Primary.Statistics;

namespace Polkanalysis.Api.Controllers
{
    public class StatsController : MasterController
    {
        private readonly IMediator _mediator;

        public StatsController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlockchainInformationAsync()
        {
            var result = await _mediator.Send(new BlockchainInformationQuery(), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("sumup")]
        public async Task<IActionResult> GetMacroStatsSumUpAsync([FromQuery] GlobalStatsQuery macroStatsQuery)
        {
            var result = await _mediator.Send(macroStatsQuery, CancellationToken.None);

            //return Helpers.Error(new ErrorResult()
            //{
            //    Status = ErrorResult.ErrorType.InvalidParam,
            //    Description = string.Join(", ", failures.Select(x => x.ErrorMessage).ToArray())
            //});

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("holders")]
        public async Task<IActionResult> GetHoldersAsync()
        {
            var result = await _mediator.Send(new HoldersQuery(), CancellationToken.None);

            if (result.IsError)
            {
                return Forbid();
            }

            return Ok(result.Value);
        }
    }
}
