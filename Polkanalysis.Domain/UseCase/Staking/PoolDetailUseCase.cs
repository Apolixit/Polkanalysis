using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Domain.UseCase.Parachain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Staking
{
    public class PoolDetailUseCase : UseCase<PoolDetailUseCase, PoolDto, PoolDetailQuery>
    {
        private readonly IStakingRepository _stakingRepository;

        public PoolDetailUseCase(IStakingRepository roleMemberRepository, ILogger<PoolDetailUseCase> logger) : base(logger)
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
