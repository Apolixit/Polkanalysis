using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Logs;

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
        public async Task<ActionResult<BlockDto>> GetBlockAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockId));
        }

        [HttpGet("{blockId}/extrinsics")]
        [Produces(typeof(IEnumerable<ExtrinsicDto>))]
        public async Task<ActionResult<IEnumerable<ExtrinsicDto>>> GetExtrinsicsAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new ExtrinsicsQuery()
            {
                BlockNumber = blockId
            });
        }

        [HttpGet("{blockId}/events")]
        [Produces(typeof(IEnumerable<EventDto>))]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new EventsQuery()
            {
                BlockId = blockId
            });
        }

        [HttpGet("{blockId}/logs")]
        [Produces(typeof(IEnumerable<LogDto>))]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogs(uint blockId)
        {
            return await SendAndHandleResponseAsync(new LogsQuery()
            {
                BlockNumber = blockId
            });
        }

        [HttpGet("extrinsic/{blockId}/{extrinsicIndex}")]
        [Produces(typeof(ExtrinsicDto))]
        public async Task<ActionResult<ExtrinsicDto>> GetExtrinsicDetailAsync(uint blockId, uint extrinsicIndex)
        {
            return await SendAndHandleResponseAsync(new ExtrinsicDetailQuery()
            {
                BlockNumber = blockId,
                ExtrinsicIndex = extrinsicIndex
            });
        }

        [HttpGet("event/{blockId}/{eventIndex}")]
        [Produces(typeof(EventDto))]
        public async Task<ActionResult<EventDto>> GetEventDetailAsync(uint blockId, uint eventIndex)
        {
            return await SendAndHandleResponseAsync(new EventDetailQuery()
            {
                BlockNumber = blockId,
                EventIndex = eventIndex
            });
        }
    }
}
