using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Service;
using System.Text.Json;

namespace Polkanalysis.Domain.UseCase.Staking.Nominator
{
    public class NominatorsHandler : Handler<NominatorsHandler, IEnumerable<NominatorLightDto>, NominatorsQuery>
    {
        private readonly IStakingService _stakingRepository;

        public const int CacheDurationInMinutes = 30;

        public NominatorsHandler(IStakingService roleMemberRepository, ILogger<NominatorsHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _stakingRepository = roleMemberRepository;
        }

        public async override Task<Result<IEnumerable<NominatorLightDto>, ErrorResult>> HandleInnerAsync(NominatorsQuery request, CancellationToken cancellationToken)
        {
            var result = Enumerable.Empty<NominatorLightDto>();

            if (request.ValidatorAddress != null)
            {
                result = await _stakingRepository.GetNominatorsBoundedToValidatorAsync(request.ValidatorAddress, cancellationToken);
            }
            else
            {
                result = await _stakingRepository.GetNominatorsAsync(cancellationToken);
            }
            return Helpers.Ok(result);
        }
    }
}
