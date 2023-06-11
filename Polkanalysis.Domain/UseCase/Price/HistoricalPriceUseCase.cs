using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Common.Database;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Price
{
    public class HistoricalPriceUseCase : UseCase<HistoricalPriceUseCase, HistoricalPriceDto, HistoricalPriceQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public HistoricalPriceUseCase(SubstrateDbContext dbContext, ILogger<HistoricalPriceUseCase> logger) : base(logger)
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
                Date = x.Date,
                Price = x.Price,
            }) }));
        }
    }
}
