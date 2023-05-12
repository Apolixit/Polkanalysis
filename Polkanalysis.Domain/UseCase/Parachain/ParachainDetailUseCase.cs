using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.UseCase.Nominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Parachain
{
    public class ParachainDetailUseCase : UseCase<ParachainDetailUseCase, ParachainDto, ParachainDetailQuery>
    {
        private readonly IParachainRepository _parachainRepository;
        public ParachainDetailUseCase(
            IParachainRepository parachainRepository, 
            ILogger<ParachainDetailUseCase> logger) : base(logger)
        {
            _parachainRepository = parachainRepository;
        }

        public override async Task<Result<ParachainDto, ErrorResult>> Handle(ParachainDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            //_parachainRepository.GetParachainDetailAsync(request)
            return null;
        }
    }
}
