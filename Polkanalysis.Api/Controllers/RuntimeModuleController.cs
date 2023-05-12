using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Api.Controllers
{
    public class RuntimeModuleController : MasterController
    {
        private readonly IMediator _mediator;

        public RuntimeModuleController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetModulesAsync() {
            var result = await _mediator.Send(new ModulesQuery(), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("{moduleName}")]
        public async Task<IActionResult> GetModuleAsync(string moduleName)
        {
            if (string.IsNullOrEmpty(moduleName)) BadRequest();

            var result = await _mediator.Send(new ModuleDetailQuery(moduleName), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }
    }
}
