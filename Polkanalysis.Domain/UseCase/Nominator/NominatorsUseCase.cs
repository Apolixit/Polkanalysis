﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Staking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Nominator
{
    public class NominatorsUseCase : UseCase<NominatorsUseCase, IEnumerable<NominatorLightDto>, NominatorsQuery>
    {
        private readonly IStakingRepository _stakingRepository;
        public NominatorsUseCase(IStakingRepository roleMemberRepository, ILogger<NominatorsUseCase> logger) : base(logger)
        {
            _stakingRepository = roleMemberRepository;
        }

        public async override Task<Result<IEnumerable<NominatorLightDto>, ErrorResult>> Handle(NominatorsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = Enumerable.Empty<NominatorLightDto>();

            if(request.ValidatorAddress != null)
            {
                result = await _stakingRepository.GetNominatorsBoundedToValidatorAsync(request.ValidatorAddress, cancellationToken);
            } else
            {
                result = await _stakingRepository.GetNominatorsAsync(cancellationToken);
            }
            
            return Helpers.Ok(result);
        }
    }
}
