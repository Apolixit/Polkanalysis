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
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class ExplorerController : MasterController
    {
        private readonly ILogger<ExplorerController> _logger;

        public ExplorerController(IMediator mediator, ILogger<ExplorerController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("blockhash")]
        [Produces(typeof(BlockDto))]
        [Description("Retrieve block by his block hash")]
        public async Task<ActionResult<BlockDto>> GetBlockAsync([FromQuery] string blockHash)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockHash));
        }

        [HttpGet("blocknumber")]
        [Produces(typeof(BlockDto))]
        [Description("Retrieve block by his block number")]
        public async Task<ActionResult<BlockDto>> GetBlockAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockId));
        }

        [HttpGet("{blockId}/extrinsics")]
        [Produces(typeof(IEnumerable<ExtrinsicDto>))]
        [Description("Return extrinsics link to given block")]
        public async Task<ActionResult<IEnumerable<ExtrinsicDto>>> GetExtrinsicsAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new ExtrinsicsQuery()
            {
                BlockNumber = blockId
            });
        }

        [HttpGet("{blockId}/events")]
        [Produces(typeof(IEnumerable<EventDto>))]
        [Description("Return events linked to given block")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new EventsQuery()
            {
                BlockId = blockId
            });
        }

        [HttpGet("{blockId}/logs")]
        [Produces(typeof(IEnumerable<LogDto>))]
        [Description("Return logs link to given block")]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogsAsync(uint blockId)
        {
            return await SendAndHandleResponseAsync(new LogsQuery()
            {
                BlockNumber = blockId
            });
        }

        [HttpGet("extrinsic/{blockId}/{extrinsicIndex}")]
        [Produces(typeof(ExtrinsicDto))]
        [Description("Return an extrinsic link to given block and extrinsic index")]
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
        [Description("Return an event link to given block and event index")]
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
