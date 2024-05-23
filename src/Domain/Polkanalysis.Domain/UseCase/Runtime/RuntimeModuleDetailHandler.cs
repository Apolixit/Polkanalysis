using Polkanalysis.Domain.Contracts.Dto.Module;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Service;
using Microsoft.Extensions.Caching.Distributed;

namespace Polkanalysis.Domain.UseCase.Runtime
{
    public class RuntimeModuleDetailHandler : Handler<RuntimeModuleDetailHandler, ModuleDetailDto, RuntimeModuleDetailQuery>
    {
        private readonly IModuleInformationService _moduleService;
        public RuntimeModuleDetailHandler(
            ILogger<RuntimeModuleDetailHandler> logger, 
            IModuleInformationService moduleRepository, IDistributedCache cache) : base(logger, cache)
        {
            _moduleService = moduleRepository;
        }

        public override async Task<Result<ModuleDetailDto, ErrorResult>> HandleInnerAsync(RuntimeModuleDetailQuery command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            if(string.IsNullOrEmpty(command.ModuleName))
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, "No module name specified");
            }

            var moduleDetail = _moduleService.GetModuleDetail(command.ModuleName);

            if(moduleDetail == null)
            {
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, $"{command.ModuleName} not found");
            }

            return Helpers.Ok(moduleDetail);
        }
    }
}
