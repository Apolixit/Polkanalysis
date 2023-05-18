using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Api.Controllers
{
    public class RuntimeController : MasterController
    {
        private readonly ILogger<RuntimeController> _logger;

        public RuntimeController(IMediator mediator, ILogger<RuntimeController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("modules")]
        [Produces(typeof(IEnumerable<ModuleDetailDto>))]
        public async Task<ActionResult<IEnumerable<ModuleDetailDto>>> GetModulesAsync() {
            return await SendAndHandleResponseAsync(new RuntimeModulesQuery());
        }

        [HttpGet("modules/{moduleName}")]
        [Produces(typeof(ModuleDetailDto))]
        public async Task<ActionResult<ModuleDetailDto>> GetModuleAsync(string moduleName)
        {
            return await SendAndHandleResponseAsync(new RuntimeModuleDetailQuery(moduleName));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<RuntimeVersionDto>))]
        public async Task<ActionResult<IEnumerable<RuntimeVersionDto>>> GetRuntimesAsync()
        {
            return await SendAndHandleResponseAsync(new RuntimeVersionQuery());
        }

        [HttpGet("runtimeId")]
        [Produces(typeof(IEnumerable<ModuleDetailDto>))]
        public async Task<ActionResult<IEnumerable<ModuleDetailDto>>> GetRuntimeAsync(uint runtimeId)
        {
            return await SendAndHandleResponseAsync(new RuntimeModulesQuery()
            {
                runtimeId = runtimeId
            });
        }
    }
}
