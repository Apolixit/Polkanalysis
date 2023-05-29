﻿using Polkanalysis.Domain.Contracts.Primary;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;

namespace Polkanalysis.Domain.UseCase.Validator
{
    public class ValidatorDetailUseCase : UseCase<ValidatorDetailUseCase, ValidatorDto, ValidatorDetailQuery>
    {
        private readonly IStakingRepository _roleMemberRepository;

        public ValidatorDetailUseCase(ILogger<ValidatorDetailUseCase> logger) : base(logger)
        {
        }

        public ValidatorDetailUseCase(IStakingRepository roleMemberRepository, ILogger<ValidatorDetailUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public override async Task<Result<ValidatorDto, ErrorResult>> Handle(ValidatorDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _roleMemberRepository.GetValidatorDetailAsync(request.ValidatorAddress, cancellationToken);
            return Helpers.Ok(result);
        }
    }
}
