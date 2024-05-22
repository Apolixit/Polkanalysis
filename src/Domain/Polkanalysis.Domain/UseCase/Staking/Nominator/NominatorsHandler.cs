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
        private readonly IDistributedCache _cache;

        public const int CacheDurationInMinutes = 30;

        public NominatorsHandler(IStakingService roleMemberRepository, ILogger<NominatorsHandler> logger, IDistributedCache cache) : base(logger)
        {
            _stakingRepository = roleMemberRepository;
            _cache = cache;
        }

        public async override Task<Result<IEnumerable<NominatorLightDto>, ErrorResult>> Handle(NominatorsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            string cacheKey = GenerateCacheKey(request);
            var result = Enumerable.Empty<NominatorLightDto>();

            var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);
            if (cachedData is not null)
            {
                _logger.LogInformation($"Cache hit for key: {cacheKey}");
                var cachedResult = JsonSerializer.Deserialize<IEnumerable<NominatorLightDto>>(cachedData);
                return Helpers.Ok(cachedResult!);
            }

            _logger.LogInformation($"Cache miss for key: {cacheKey}");

            if (request.ValidatorAddress is not null)
            {
                result = await _stakingRepository.GetNominatorsBoundedToValidatorAsync(request.ValidatorAddress, cancellationToken);
            }
            else
            {
                result = await _stakingRepository.GetNominatorsAsync(cancellationToken);
            }

            // Serialize the result and store it in the cache
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(CacheDurationInMinutes)
            };
            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result), cacheOptions, cancellationToken);

            return Helpers.Ok(result!);
        }

        private string GenerateCacheKey(NominatorsQuery request)
        {
            if (request.ValidatorAddress != null)
            {
                return $"Nominators_{request.ValidatorAddress}";
            }
            return "Nominators_All";
        }
    }
}
