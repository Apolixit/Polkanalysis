using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Staking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Nominator
{
    public class NominatorsUseCase : UseCase<NominatorsUseCase, IEnumerable<NominatorLightDto>, NominatorsQuery>
    {
        private readonly IRoleMemberRepository _roleMemberRepository;
        public NominatorsUseCase(IRoleMemberRepository roleMemberRepository, ILogger<NominatorsUseCase> logger) : base(logger)
        {
            _roleMemberRepository = roleMemberRepository;
        }

        public async override Task<Result<IEnumerable<NominatorLightDto>, ErrorResult>> Handle(NominatorsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _roleMemberRepository.GetNominatorsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
