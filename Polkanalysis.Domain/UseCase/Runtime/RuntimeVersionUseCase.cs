using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Runtime
{
    public class RuntimeVersionUseCase : UseCase<RuntimeModulesUseCase, IEnumerable<RuntimeVersionDto>, RuntimeVersionQuery>
    {
        public RuntimeVersionUseCase(ILogger<RuntimeModulesUseCase> logger) : base(logger)
        {
        }

        public async override Task<Result<IEnumerable<RuntimeVersionDto>, ErrorResult>> Handle(RuntimeVersionQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            throw new NotImplementedException();
        }
    }
}
