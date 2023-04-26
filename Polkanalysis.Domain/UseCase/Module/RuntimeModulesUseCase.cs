using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Module
{
    public class RuntimeModulesUseCase : UseCase<RuntimeModulesUseCase, IEnumerable<ModuleDetailDto>, ModulesQuery>
    {
        private readonly IModuleInformation _moduleRepository;
        private readonly ISubstrateRepository _substrateRepository;

        public RuntimeModulesUseCase(
            ILogger<RuntimeModulesUseCase> logger,
            ISubstrateRepository substrateRepository,
            IModuleInformation moduleRepository) : base(logger)
        {
            _moduleRepository = moduleRepository;
            _substrateRepository = substrateRepository;
        }

        public override async Task<Result<IEnumerable<ModuleDetailDto>, ErrorResult>> Handle(ModulesQuery command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            var modules = _substrateRepository.RuntimeMetadata.NodeMetadata.Modules.Select(x => _moduleRepository.GetModuleDetail(x.Value.Name));

            if (!modules.Any())
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, "No module has been found in metadata");
            }

            return Helpers.Ok(modules);
        }
    }
}
