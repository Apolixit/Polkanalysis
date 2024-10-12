using Microsoft.Extensions.Caching.Distributed;
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
        private readonly IMetadataService _metadataService;
        private readonly ISubstrateService _substrateService;

        public RuntimeModulesHandler(
            ILogger<RuntimeModulesHandler> logger,
            ISubstrateService substrateRepository,
            IMetadataService metadataService, IDistributedCache cache) : base(logger, cache)
        {
            _metadataService = metadataService;
            _substrateService = substrateRepository;
        }

        public override async Task<Result<IEnumerable<ModuleDetailDto>, ErrorResult>> HandleInnerAsync(RuntimeModulesQuery request, CancellationToken cancellationToken)
        {
            var metadata = await _substrateService.GetMetadataAsync(cancellationToken);

            List<Task<ModuleDetailDto>> modulesTask = new();
            foreach ( var module in metadata.NodeMetadata.Modules) {
                modulesTask.Add(_metadataService.GetModuleDetailAsync(module.Value.Name, cancellationToken));
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
