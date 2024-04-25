using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Primary.Statistics.Account;
using Polkanalysis.Domain.Contracts.Primary.Statistics;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Financial;
using Polkanalysis.Domain.Contracts.Primary.FInancial;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class StatsController : MasterController
    {
        public StatsController(IMediator mediator, ILogger<StatsController> logger) : base(mediator, logger)
        {
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
            return await SendAndHandleResponseAsync(new HoldersQuery());
        }

        [HttpGet()]
        [Produces(typeof(GlobalFinanceDto))]
        [Description("Return transactions synthesis between given dates")]
        public async Task<ActionResult<GlobalFinanceDto>> GetFinancialGlobalTransactionsAsync(DateTime? from, DateTime? to)
        {
            return await SendAndHandleResponseAsync(new GlobalFinanceQuery(from, to));
        }
    }
}
