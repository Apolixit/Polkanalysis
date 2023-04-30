using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;

namespace Polkanalysis.Domain.UseCase.Module
{
    public class RuntimeModuleDetailUseCase : UseCase<RuntimeModuleDetailUseCase, ModuleDetailDto, ModuleDetailQuery>
    {
        private readonly IModuleInformation _moduleRepository;
        public RuntimeModuleDetailUseCase(
            ILogger<RuntimeModuleDetailUseCase> logger, 
            IModuleInformation moduleRepository) : base(logger)
        {
            _moduleRepository = moduleRepository;
        }

        public override async Task<Result<ModuleDetailDto, ErrorResult>> Handle(ModuleDetailQuery command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            if(string.IsNullOrEmpty(command.ModuleName))
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, "No module name specified");
            }

            var moduleDetail = _moduleRepository.GetModuleDetail(command.ModuleName);

            if(moduleDetail == null)
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{command.ModuleName} not found");
            }

            return Helpers.Ok(moduleDetail);
        }
    }
}
