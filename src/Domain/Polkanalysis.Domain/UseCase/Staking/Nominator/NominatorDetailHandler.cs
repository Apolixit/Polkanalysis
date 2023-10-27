using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Staking.Nominator
{
    public class NominatorDetailHandler : Handler<NominatorDetailHandler, NominatorDto, NominatorDetailQuery>
    {
        private readonly IStakingService _stakingService;
        public NominatorDetailHandler(IStakingService roleMemberRepository, ILogger<NominatorDetailHandler> logger) : base(logger)
        {
            _stakingService = roleMemberRepository;
        }

        public override async Task<Result<NominatorDto, ErrorResult>> Handle(NominatorDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _stakingService.GetNominatorDetailAsync(request.NominatorAddress, cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
