using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Service;
using Microsoft.Extensions.Caching.Distributed;

namespace Polkanalysis.Domain.UseCase.Staking.Validator
{
    public class ValidatorDetailHandler : Handler<ValidatorDetailHandler, ValidatorDto, ValidatorDetailQuery>
    {
        private readonly IStakingService _stakingService;

        public ValidatorDetailHandler(IStakingService stakingService, ILogger<ValidatorDetailHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _stakingService = stakingService;
        }

        public override async Task<Result<ValidatorDto, ErrorResult>> HandleInnerAsync(ValidatorDetailQuery request, CancellationToken cancellationToken)
        {
            if(!string.IsNullOrEmpty(request.ValidatorAddress))
            {
                return Helpers.Ok(await _stakingService.GetValidatorDetailAsync(request.ValidatorAddress, cancellationToken));
            }

            return UseCaseError(ErrorResult.ErrorType.EmptyModel, "Invalid validator model query");
        }
    }
}
