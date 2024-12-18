using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Era
{
    public class ErasHandler : Handler<ErasHandler, IEnumerable<EraLightDto>, ErasQuery>
    {
        private readonly IStakingService _stakingRepository;

        public ErasHandler(IStakingService stakingRepository, ILogger<ErasHandler> logger, HybridCache cache) : base(logger, cache)
        {
            _stakingRepository = stakingRepository;
        }

        public async override Task<Result<IEnumerable<EraLightDto>, ErrorResult>> HandleInnerAsync(ErasQuery request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Empty<EraLightDto>();
            if (request.ValidatorAddress != null)
            {
                result = await _stakingRepository.GetErasBoundedToValidatorAsync(request.ValidatorAddress, cancellationToken);
            }

            return Helpers.Ok(result);
        }
    }
}
