using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Runtime
{
    public class RuntimeVersionHandler : Handler<RuntimeModulesHandler, IEnumerable<SpecVersionDto>, RuntimeVersionQuery>
    {
        private readonly IModuleInformationService _moduleService;

        public RuntimeVersionHandler(ILogger<RuntimeModulesHandler> logger, IModuleInformationService moduleService, IDistributedCache cache) : base(logger, cache)
        {
            _moduleService = moduleService;
        }

        public async override Task<Result<IEnumerable<SpecVersionDto>, ErrorResult>> HandleInnerAsync(RuntimeVersionQuery request, CancellationToken cancellationToken)
        {
            var result = await _moduleService.GetRuntimeVersionsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
