using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Price;

namespace Polkanalysis.Domain.UseCase.Price
{
    public class HistoricalPriceHandler : Handler<HistoricalPriceHandler, HistoricalPriceDto, HistoricalPriceQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public HistoricalPriceHandler(SubstrateDbContext dbContext, ILogger<HistoricalPriceHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<HistoricalPriceDto, ErrorResult>> Handle(HistoricalPriceQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TokenPriceModel> prices = _dbContext.TokenPrices;

            if(request.From is not null)
            {
                prices = prices.Where(x => x.Date >= request.From.Value);
            }

            if (request.To is not null)
            {
                prices = prices.Where(x => x.Date <= request.To.Value);
            }

            return await Task.Run(() => Helpers.Ok(new HistoricalPriceDto() { TokenPrices = prices.Select(x => new TokenPriceDto()
            {
                CompareToCurrency = CurrencyDto.USD,
                Date = x.Date.ToUniversalTime(),
                Price = x.Price,
            }) }));
        }
    }
}
