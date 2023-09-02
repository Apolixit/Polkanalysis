using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Polkanalysis.Api.Services;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    [EnableRateLimiting(ApiRateLimitOptions.FixedPolicy)]
    public class PriceController : MasterController
    {
        public PriceController(IMediator mediator, ILogger<PriceController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Produces(typeof(TokenPriceDto))]
        [Description("Get token price for current connected blockchain at given date")]
        public async Task<ActionResult<TokenPriceDto>> GetPriceAtDateAsync(DateTime date)
        {
            return await SendAndHandleResponseAsync(new TokenPriceQuery()
            {
                CoinId = "polkadot",
                Date = date
            });
        }

        [HttpGet("{from}/{to}")]
        [Produces(typeof(HistoricalPriceDto))]
        [Description("Retrieve token price for current connected blockchain between two dates")]
        public async Task<ActionResult<HistoricalPriceDto>> GetPriceBetweenDateAsync(DateTime from, DateTime to)
        {
            return await SendAndHandleResponseAsync(new HistoricalPriceQuery()
            {
                From = from,
                To = to
            });
        }
    }
}
