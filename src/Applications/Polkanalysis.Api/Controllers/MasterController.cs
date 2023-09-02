using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary;
using System.Runtime.CompilerServices;

namespace Polkanalysis.Api.Controllers
{
    [ApiController]
    [Route("api/polkadot/[controller]")]
    public class MasterController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly ILogger<MasterController> _logger;

        public MasterController(IMediator mediator, ILogger<MasterController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        protected async Task<ActionResult<TResponse>> SendAndHandleResponseAsync<TResponse>(
            IRequest<Result<TResponse, ErrorResult>> request, [CallerMemberName] string callerName = "")
        {
            var result = await _mediator.Send(request, CancellationToken.None);

            if (result.IsError)
            {
                _logger.LogError("{caller} endpoint called and returned the following error : {errorMessage}", callerName, result.Error?.Description);
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
