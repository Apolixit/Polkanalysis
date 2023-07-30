using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using System.ComponentModel;

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
        [Description("Get runtimes modules for current runtime version")]
        public async Task<ActionResult<IEnumerable<ModuleDetailDto>>> GetModulesAsync() {
            return await SendAndHandleResponseAsync(new RuntimeModulesQuery());
        }

        [HttpGet("modules/{moduleName}")]
        [Produces(typeof(ModuleDetailDto))]
        [Description("Get runtime module by his name")]
        public async Task<ActionResult<ModuleDetailDto>> GetModuleAsync(string moduleName)
        {
            return await SendAndHandleResponseAsync(new RuntimeModuleDetailQuery(moduleName));
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<SpecVersionDto>))]
        [Description("Get list of runtimes")]
        public async Task<ActionResult<IEnumerable<SpecVersionDto>>> GetRuntimesAsync()
        {
            return await SendAndHandleResponseAsync(new RuntimeVersionQuery());
        }

        [HttpGet("runtimeId")]
        [Produces(typeof(IEnumerable<ModuleDetailDto>))]
        [Description("Get a runtime by it runtime number")]
        public async Task<ActionResult<IEnumerable<ModuleDetailDto>>> GetRuntimeAsync(uint runtimeId)
        {
            return await SendAndHandleResponseAsync(new RuntimeModulesQuery()
            {
                runtimeId = runtimeId
            });
        }

        [HttpGet("versions")]
        [Produces(typeof(IEnumerable<SpecVersionDto>))]
        [Description("Return all runtime versions")]
        public async Task<ActionResult<IEnumerable<SpecVersionDto>>> GetSpecVersionAsync()
        {
            return await SendAndHandleResponseAsync(new SpecVersionsQuery()
            {
            });
        }

        [HttpGet("version/{versionNumber}")]
        [Produces(typeof(SpecVersionDto))]
        [Description("Return given runtime version")]
        public async Task<ActionResult<SpecVersionDto?>> GetSpecVersionByNumberAsync(uint versionNumber)
        {
            var res = await SendAndHandleResponseAsync(new SpecVersionsQuery()
            {
                SpecVersionNumber = versionNumber
            });
            if (res == null) return Ok(null);

            return res!.Value.FirstOrDefault();
        }
    }
}
