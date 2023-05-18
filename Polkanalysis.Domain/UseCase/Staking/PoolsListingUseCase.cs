using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Staking;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Parachain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Staking
{
    public class PoolsListingUseCase : UseCase<PoolsListingUseCase, IEnumerable<PoolLightDto>, PoolsQuery>
    {
        private readonly IStakingRepository _roleMemberRepository;

        public PoolsListingUseCase(IStakingRepository roleMemberRepository, ILogger<PoolsListingUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public override Task<Result<IEnumerable<PoolLightDto>, ErrorResult>> Handle(PoolsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
