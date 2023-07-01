using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Validator
{
    public class ValidatorDetailHandler : Handler<ValidatorDetailHandler, ValidatorDto, ValidatorDetailQuery>
    {
        private readonly IStakingService _stakingService;

        public ValidatorDetailHandler(ILogger<ValidatorDetailHandler> logger) : base(logger)
        {
        }

        public ValidatorDetailHandler(IStakingService roleMemberRepository, ILogger<ValidatorDetailHandler> logger) : base(logger)
        {
            _stakingService = roleMemberRepository;
        }

        public override async Task<Result<ValidatorDto, ErrorResult>> Handle(ValidatorDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            if(!string.IsNullOrEmpty(request.ValidatorAddress))
            {
                return Helpers.Ok(await _stakingService.GetValidatorDetailAsync(request.ValidatorAddress, cancellationToken));
            }

            return UseCaseError(ErrorResult.ErrorType.EmptyModel, "Invalid validator model query");
        }
    }
}
