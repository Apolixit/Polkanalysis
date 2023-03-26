using Microsoft.Extensions.Logging;
using OperationResult;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Primary;
using Substats.Domain.UseCase.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.UseCase.Nominator
{
    public class NominatorDetailUseCase : UseCase<NominatorDetailUseCase, NominatorDto, NominatorCommand>
    {
        public NominatorDetailUseCase(ILogger<NominatorDetailUseCase> logger) : base(logger)
        {
        }

        public override async Task<Result<NominatorDto, ErrorResult>> ExecuteAsync(NominatorCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            return null;
        }
    }
}
