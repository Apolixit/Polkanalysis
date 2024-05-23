using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Parachain
{
    public class ParachainListingHandler : Handler<ParachainListingHandler, IEnumerable<ParachainLightDto>, ParachainsQuery>
    {
        private readonly IParachainService _parachainRepository;
        public ParachainListingHandler(
            IParachainService parachainRepository,
            ILogger<ParachainListingHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<IEnumerable<ParachainLightDto>, ErrorResult>> HandleInnerAsync(ParachainsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _parachainRepository.GetParachainsAsync(cancellationToken);
            return Helpers.Ok(result);
        }
    }
}
