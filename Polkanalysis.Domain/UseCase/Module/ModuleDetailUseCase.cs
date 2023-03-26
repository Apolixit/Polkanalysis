using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Module
{
    public class ModuleDetailUseCase : UseCase<ModuleDetailUseCase, ModuleDetailDto, ModuleCommand>
    {
        public ModuleDetailUseCase(ILogger<ModuleDetailUseCase> logger) : base(logger)
        {
        }

        public override async Task<Result<ModuleDetailDto, ErrorResult>> ExecuteAsync(ModuleCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            return null;
        }
    }
}
