using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Common.Database;
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

        public override Task<Result<HistoricalPriceDto, ErrorResult>> Handle(HistoricalPriceQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
