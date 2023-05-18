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
    public class PoolDetailUseCase : UseCase<PoolDetailUseCase, PoolDto, PoolDetailQuery>
    {
        private readonly IRoleMemberRepository _roleMemberRepository;

        public PoolDetailUseCase(IRoleMemberRepository roleMemberRepository, ILogger<PoolDetailUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public override Task<Result<PoolDto, ErrorResult>> Handle(PoolDetailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
