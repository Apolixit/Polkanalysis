using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase.Nominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Parachain
{
    public class ParachainDetailUseCase : UseCase<ParachainDetailUseCase, ParachainDto, ParachainCommand>
    {
        public ParachainDetailUseCase(ILogger<ParachainDetailUseCase> logger) : base(logger)
        {
        }

        public override async Task<Result<ParachainDto, ErrorResult>> ExecuteAsync(ParachainCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            return null;
        }
    }
}
