﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Primary.Statistics.Account;
using Polkanalysis.Domain.Contracts.Primary.Statistics;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using Polkanalysis.Domain.Contracts.Dto.Module;

namespace Polkanalysis.Api.Controllers
{
    public class StatsController : MasterController
    {
        private readonly ILogger<StatsController> _logger;

        public StatsController(IMediator mediator, ILogger<StatsController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces(typeof(BlockchainInformationDto))]
        public async Task<ActionResult<BlockchainInformationDto>> GetBlockchainInformationAsync()
        {
            return await SendAndHandleResponseAsync(new BlockchainInformationQuery());
        }

        [HttpGet("sumup")]
        [Produces(typeof(GlobalStatsDto))]
        public async Task<ActionResult<GlobalStatsDto>> GetMacroStatsSumUpAsync([FromQuery] GlobalStatsQuery macroStatsQuery)
        {
            return await SendAndHandleResponseAsync(macroStatsQuery);
        }

        [HttpGet("holders")]
        [Produces(typeof(int))]
        public async Task<ActionResult<int>> GetHoldersAsync()
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
