using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.UseCase.Runtime
{
    public class RuntimeModulesHandler : Handler<RuntimeModulesHandler, IEnumerable<ModuleDetailDto>, RuntimeModulesQuery>
    {
        private readonly IModuleInformationService _moduleService;
        private readonly ISubstrateService _substrateService;

        public RuntimeModulesHandler(
            ILogger<RuntimeModulesHandler> logger,
            ISubstrateService substrateRepository,
            IModuleInformationService moduleRepository) : base(logger)
        {
            _moduleService = moduleRepository;
            _substrateService = substrateRepository;
        }

        public override async Task<Result<IEnumerable<ModuleDetailDto>, ErrorResult>> Handle(RuntimeModulesQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            List<Task<ModuleDetailDto>> modulesTask = new();
            foreach ( var module in _substrateService.RuntimeMetadata.NodeMetadata.Modules) {
                modulesTask.Add(Task.Run(() => _moduleService.GetModuleDetail(module.Value.Name)));
            }

            var modules = (IEnumerable<ModuleDetailDto>)await Task.WhenAll( modulesTask );

            if (modules == null || !modules.Any())
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, "No module has been found in metadata");
            }

            return Helpers.Ok(modules);
        }
    }
}
