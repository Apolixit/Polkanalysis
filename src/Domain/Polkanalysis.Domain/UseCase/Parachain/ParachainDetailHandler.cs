using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Parachain
{
    public class ParachainDetailHandler : Handler<ParachainDetailHandler, ParachainDto, ParachainDetailQuery>
    {
        private readonly IParachainService _parachainRepository;
        public ParachainDetailHandler(
            IParachainService parachainRepository, 
            ILogger<ParachainDetailHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _parachainRepository = parachainRepository;
        }

        public override async Task<Result<ParachainDto, ErrorResult>> HandleInnerAsync(ParachainDetailQuery request, CancellationToken cancellationToken)
        {
            var parachainDto = await _parachainRepository.GetParachainDetailAsync(request.ParachainId, cancellationToken);

            return Helpers.Ok(parachainDto);
        }
    }
}
