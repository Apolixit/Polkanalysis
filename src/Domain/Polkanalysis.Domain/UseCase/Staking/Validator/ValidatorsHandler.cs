﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Validator
{
    public class ValidatorsHandler : Handler<ValidatorsHandler, IEnumerable<ValidatorLightDto>, ValidatorsQuery>
    {
        private readonly IStakingService _stakingService;

        public ValidatorsHandler(IStakingService stakingService, ILogger<ValidatorsHandler> logger) : base(logger)
        {
            _stakingService = stakingService;
        }

        public async override Task<Result<IEnumerable<ValidatorLightDto>, ErrorResult>> Handle(ValidatorsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            if (!string.IsNullOrEmpty(request.ElectedByNominator))
            {
                return Helpers.Ok(await _stakingService.GetValidatorsElectedByNominatorAsync(request.ElectedByNominator, cancellationToken));
            }

            var result = await _stakingService.GetValidatorsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
