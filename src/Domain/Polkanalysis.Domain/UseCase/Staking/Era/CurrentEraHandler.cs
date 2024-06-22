using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Era;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Era
{
    public class CurrentEraHandler : Handler<CurrentEraHandler, CurrentEraDto, CurrentEraInformationQuery>
    {
        private readonly IStakingService _stakingRepository;

        public CurrentEraHandler(IStakingService stakingRepository, ILogger<CurrentEraHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _stakingRepository = stakingRepository;
        }

        public async override Task<Result<CurrentEraDto, ErrorResult>> HandleInnerAsync(CurrentEraInformationQuery request, CancellationToken cancellationToken)
        {
            return await _stakingRepository.CurrentEraInformationAsync(cancellationToken);
        }
    }
}
