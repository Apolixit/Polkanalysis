using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;

namespace Polkanalysis.Domain.UseCase.Explorer.Extrinsics
{
    public class SearchExtrinsicsHandler : Handler<SearchExtrinsicsHandler, IQueryable<ExtrinsicLightDto>, SearchExtrinsicsQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public SearchExtrinsicsHandler(ILogger<SearchExtrinsicsHandler> logger, HybridCache cache, SubstrateDbContext dbContext) : base(logger, cache)
        {
            _dbContext = dbContext;
        }

        public override async Task<Result<IQueryable<ExtrinsicLightDto>, ErrorResult>> HandleInnerAsync(SearchExtrinsicsQuery request, CancellationToken cancellationToken)
        {
            var res = _dbContext.ExtrinsicsInformation.Select(x => new ExtrinsicLightDto()
            {
                ExtrinsicId = string.Format("{0}-{1}", x.BlockNumber, x.ExtrinsicIndex),
                BlockNumber = x.BlockNumber,
                Method = x.Method,
                Event = x.Event,
                BlockDate = x.BlockDate,
                AccountAddress = x.AccountAddress,
                Status = x.Status,
                Lifetime = x.Lifetime != null ? new LifetimeDto()
                {
                    IsImmortal = x.Lifetime.IsImmortal,
                    FromBlock = x.Lifetime.StartBlock,
                    ToBlock = x.Lifetime.EndBlock
                } : null,
                Fees = x.Fees,
                IsSigned = x.IsSigned
            }).AsQueryable();
            
            return Helpers.Ok(res);
        }
    }
}
