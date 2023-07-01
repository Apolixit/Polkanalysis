using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Api.Controllers
{
    [ApiController]
    [Route("api/polkadot/[controller]")]
    public class MasterController : Controller
    {
        protected readonly IMediator _mediator;

        public MasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult<TResponse>> SendAndHandleResponseAsync<TResponse>(IRequest<Result<TResponse, ErrorResult>> request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);

            if (result.IsError)
            {
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
