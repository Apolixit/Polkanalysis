using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Parachain
{
    public class ParachainListingUseCase : UseCase<ParachainListingUseCase, ParachainLightDto, ParachainQuery>
    {
        private readonly IParachainRepository _parachainRepository;
        public ParachainListingUseCase(
            IParachainRepository parachainRepository,
            ILogger<ParachainListingUseCase> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public async override Task<Result<ParachainLightDto, ErrorResult>> Handle(ParachainQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            throw new NotImplementedException();
        }
    }
}
