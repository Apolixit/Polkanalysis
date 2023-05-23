using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Runtime
{
    public class RuntimeVersionUseCase : UseCase<RuntimeModulesUseCase, IEnumerable<RuntimeVersionDto>, RuntimeVersionQuery>
    {
        private readonly IModuleInformation _moduleRepository;

        public RuntimeVersionUseCase(ILogger<RuntimeModulesUseCase> logger, IModuleInformation moduleRepository) : base(logger)
        {
            _moduleRepository = moduleRepository;
        }

        public async override Task<Result<IEnumerable<RuntimeVersionDto>, ErrorResult>> Handle(RuntimeVersionQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var result = await _moduleRepository.GetRuntimeVersionsAsync(cancellationToken);

            return Helpers.Ok(result);
        }
    }
}
