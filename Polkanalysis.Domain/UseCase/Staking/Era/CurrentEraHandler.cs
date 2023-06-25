using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Era;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Staking.Era
{
    public class CurrentEraHandler : Handler<CurrentEraHandler, CurrentEraDto, CurrentEraInformationQuery>
    {
        private readonly IStakingService _stakingRepository;

        public CurrentEraHandler(IStakingService stakingRepository, ILogger<CurrentEraHandler> logger) : base(logger)
        {
            _stakingRepository = stakingRepository;
        }

        public async override Task<Result<CurrentEraDto, ErrorResult>> Handle(CurrentEraInformationQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            return await _stakingRepository.CurrentEraInformationAsync(cancellationToken);
        }
    }
}
