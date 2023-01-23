using Microsoft.Extensions.Logging;
using OperationResult;
using Substats.Domain.Contracts.Dto.Parachain;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Nominator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.UseCase.Parachain
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
