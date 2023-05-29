using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking;
using Polkanalysis.Domain.Contracts.Primary.Eras;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Validator
{
    public class ErasUseCase : UseCase<ErasUseCase, IEnumerable<EraLightDto>, ErasQuery>
    {
        private readonly IStakingRepository _stakingRepository;

        public ErasUseCase(IStakingRepository stakingRepository, ILogger<ErasUseCase> logger) : base(logger)
        {
            _stakingRepository = stakingRepository;
        }

        public async override Task<Result<IEnumerable<EraLightDto>, ErrorResult>> Handle(ErasQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = Enumerable.Empty<EraLightDto>();
            if (request.ValidatorAddress != null)
            {
                result = await _stakingRepository.GetErasBoundedToValidatorAsync(request.ValidatorAddress, cancellationToken);
            }

            return Helpers.Ok(result);
        }
    }
}
