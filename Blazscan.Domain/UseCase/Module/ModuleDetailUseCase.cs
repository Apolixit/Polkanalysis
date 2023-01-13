using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Module;
using Blazscan.Domain.Contracts.Primary;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Domain.UseCase.Explorer.Block;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.UseCase.Module
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
