using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;

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
        [Produces(typeof(BlockDto))]
        public async Task<ActionResult<BlockDto>> GetBlockAsync([FromQuery] string blockHash)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockHash));
        }

        [HttpGet("blocknumber")]
        [Produces(typeof(BlockDto))]
        public async Task<ActionResult<BlockDto>> GetBlockAsync([FromQuery] uint blockId)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockId));
        }
    }
}
