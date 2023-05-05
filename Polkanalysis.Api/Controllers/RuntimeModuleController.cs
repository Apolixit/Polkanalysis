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

        [HttpGet("modules")]
        public async Task<IActionResult> GetModulesAsync() {
            var result = await _mediator.Send(new ModulesQuery(), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("module")]
        public async Task<IActionResult> GetModuleAsync([FromQuery] ModuleDetailQuery query)
        {
            if (query == null) BadRequest();

            var result = await _mediator.Send(new ModuleDetailQuery(query.ModuleName), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }
    }
}
