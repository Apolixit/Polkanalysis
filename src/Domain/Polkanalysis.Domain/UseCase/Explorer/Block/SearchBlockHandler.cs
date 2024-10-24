using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.Database;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.UseCase.Explorer.Block
{
    public class SearchBlockHandler : Handler<SearchBlockHandler, IQueryable<BlockLightDto>, SearchBlocksQuery>
    {
        private readonly SubstrateDbContext _db;
        private readonly IAccountService _accountService;

        public SearchBlockHandler(SubstrateDbContext db, ILogger<SearchBlockHandler> logger, IDistributedCache cache, IAccountService accountService) : base(logger, cache)
        {
            _db = db;
            _accountService = accountService;
        }

        public async override Task<Result<IQueryable<BlockLightDto>, ErrorResult>> HandleInnerAsync(SearchBlocksQuery request, CancellationToken cancellationToken)
        {
            var res = _db.BlockInformation.Select(x => new BlockLightDto()
            {
                Number = x.BlockNumber,
                Hash = new Hash(x.BlockHash),
                NbEvents = x.EventsCount,
                NbExtrinsics = x.ExtrinsicsCount,
                NbLogs = x.LogsCount,
                Status = Contracts.Dto.GlobalStatusDto.BlockStatusDto.Finalized,
                When = ModelBuilder.DisplayElapsedTime(x.BlockDate),
                BlockDate = x.BlockDate,
                ValidatorAddress = x.ValidatorAddress,
                ValidatorIdentity = _accountService.GetAccountIdentityAsync(x.ValidatorAddress, cancellationToken)
            }).AsQueryable();

            return Helpers.Ok(res);
        }
    }
}
