using Polkanalysis.Domain.Contracts.Primary;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Validator
{
    public class ValidatorDetailHandler : Handler<ValidatorDetailHandler, ValidatorDto, ValidatorDetailQuery>
    {
        private readonly IStakingService _roleMemberRepository;

        public ValidatorDetailHandler(ILogger<ValidatorDetailHandler> logger) : base(logger)
        {
        }

        public ValidatorDetailHandler(IStakingService roleMemberRepository, ILogger<ValidatorDetailHandler> logger) : base(logger)
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
