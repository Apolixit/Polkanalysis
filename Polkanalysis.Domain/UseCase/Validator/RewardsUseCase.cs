﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Rewards;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Validator
{
    public class RewardsUseCase : UseCase<RewardsUseCase, IEnumerable<RewardDto>, RewardsQuery>
    {
        private readonly IStakingRepository _stakingRepository;

        public RewardsUseCase(IStakingRepository stakingRepository, ILogger<RewardsUseCase> logger) : base(logger)
        {
            _stakingRepository = stakingRepository;
        }

        public async override Task<Result<IEnumerable<RewardDto>, ErrorResult>> Handle(RewardsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = Enumerable.Empty<RewardDto>();
            if (request.ValidatorAddress != null)
            {
                result = await _stakingRepository.GetRewardsBoundedToValidatorAsync(request.ValidatorAddress, cancellationToken);
            }
            
            return Helpers.Ok(result);
        }
    }
}
