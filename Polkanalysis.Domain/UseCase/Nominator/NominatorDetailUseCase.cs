using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Secondary.Repository;

namespace Polkanalysis.Domain.UseCase.Nominator
{
    public class NominatorDetailUseCase : UseCase<NominatorDetailUseCase, NominatorDto, NominatorDetailQuery>
    {
        private readonly IStakingRepository _roleMemberRepository;
        public NominatorDetailUseCase(IStakingRepository roleMemberRepository, ILogger<NominatorDetailUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public override async Task<Result<NominatorDto, ErrorResult>> Handle(NominatorDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _roleMemberRepository.GetNominatorDetailAsync(request.NominatorAddress, cancellationToken);
            
            return Helpers.Ok(result);
        }
    }
}
