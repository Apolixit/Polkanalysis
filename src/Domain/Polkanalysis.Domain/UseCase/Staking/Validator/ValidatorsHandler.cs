using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
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

        public ValidatorsHandler(IStakingService stakingService, ILogger<ValidatorsHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _stakingService = stakingService;
        }

        public async override Task<Result<IEnumerable<ValidatorLightDto>, ErrorResult>> HandleInnerAsync(ValidatorsQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.ElectedByNominator))
            {
                return Helpers.Ok(await _stakingService.GetValidatorsElectedByNominatorAsync(request.ElectedByNominator, cancellationToken));
            }

            var result = await _stakingService.GetValidatorsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
