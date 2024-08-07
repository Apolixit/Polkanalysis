﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Nominator
{
    public class NominatorDetailHandler : Handler<NominatorDetailHandler, NominatorDto, NominatorDetailQuery>
    {
        private readonly IStakingService _stakingService;
        public NominatorDetailHandler(IStakingService roleMemberRepository, ILogger<NominatorDetailHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _stakingService = roleMemberRepository;
        }

        public override async Task<Result<NominatorDto, ErrorResult>> HandleInnerAsync(NominatorDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await _stakingService.GetNominatorDetailAsync(request.NominatorAddress, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
