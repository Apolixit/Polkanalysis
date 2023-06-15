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
            ILogger<ParachainDetailHandler> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public override async Task<Result<ParachainDto, ErrorResult>> Handle(ParachainDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var parachainDto = await _parachainRepository.GetParachainDetailAsync(request.ParachainId, cancellationToken);

            return Helpers.Ok(parachainDto);
        }
    }
}
