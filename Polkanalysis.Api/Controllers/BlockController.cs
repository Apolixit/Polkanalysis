using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Primary;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Polkanalysis.Api.Controllers
{
    public class BlockController : MasterController
    {
        private readonly ILogger<BlockController> _logger;

        public BlockController(IMediator mediator, ILogger<BlockController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("blockhash")]
        public async Task<IActionResult> GetBlockAsync([FromQuery] string blockHash)
        {
            var result = await _mediator.Send(new BlockDetailsCommand(blockHash), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("blocknumber")]
        public async Task<IActionResult> GetBlockAsync([FromQuery] uint blockId)
        {
            var result = await _mediator.Send(new BlockDetailsCommand(blockId), CancellationToken.None);

            if (result.IsError)
            {
                return BadRequest(result);
            }

            return Ok(result.Value);
        }

        [HttpGet("testtimeout")]
        public IActionResult GetTimeout()
        {
            Thread.Sleep(200000);
            return Ok();
        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }
    }
}
