using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Pools
{
    public class PoolDetailHandler : Handler<PoolDetailHandler, PoolDto, PoolDetailQuery>
    {
        private readonly IStakingService _stakingRepository;

        public PoolDetailHandler(IStakingService roleMemberRepository, ILogger<PoolDetailHandler> logger) : base(logger)
        {
            _stakingRepository = roleMemberRepository;
        }

        public async override Task<Result<PoolDto, ErrorResult>> Handle(PoolDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _stakingRepository.GetPoolDetailAsync(request.poolId, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
