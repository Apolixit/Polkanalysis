using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Pools
{
    public class PoolsListingHandler : Handler<PoolsListingHandler, IEnumerable<PoolLightDto>, PoolsQuery>
    {
        private readonly IStakingService _stakingRepository;

        public PoolsListingHandler(IStakingService roleMemberRepository, ILogger<PoolsListingHandler> logger) : base(logger)
        {
            _stakingRepository = roleMemberRepository;
        }

        public async override Task<Result<IEnumerable<PoolLightDto>, ErrorResult>> Handle(PoolsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _stakingRepository.GetPoolsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
