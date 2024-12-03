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
    [Produces("application/json")]
    public class ExplorerController : MasterController
    {
        public ExplorerController(IMediator mediator, ILogger<ExplorerController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Retrieve block by his block hash
        /// </summary>
        /// <param name="blockHash">The block hash</param>
        /// <returns>Block informations details</returns>
        [HttpGet("blockhash")]
        [Produces(typeof(BlockDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Retrieve block by his block hash")]
        public async Task<ActionResult<BlockDto>> GetBlockAsync([FromQuery] string blockHash)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockHash));
        }

        /// <summary>
        /// Retrieve block by his block number
        /// </summary>
        /// <param name="blockNumber">The block number</param>
        /// <returns>Block informations details</returns>
        [HttpGet("blocknumber")]
        [Produces(typeof(BlockDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Retrieve block by his block number")]
        public async Task<ActionResult<BlockDto>> GetBlockAsync(uint blockNumber)
        {
            return await SendAndHandleResponseAsync(new BlockDetailsQuery(blockNumber));
        }

        /// <summary>
        /// Return extrinsics link to given block
        /// </summary>
        /// <param name="blockNumber">The block number</param>
        /// <returns>List of extrinsics associated to this block</returns>
        [HttpGet("{blockNumber}/extrinsics")]
        [Produces(typeof(IEnumerable<ExtrinsicDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return extrinsics link to given block")]
        public async Task<ActionResult<IEnumerable<ExtrinsicDto>>> GetExtrinsicsAsync(uint blockNumber)
        {
            return await SendAndHandleResponseAsync(new ExtrinsicsQuery()
            {
                BlockNumber = blockNumber
            });
        }

        /// <summary>
        /// Return events linked to given block
        /// </summary>
        /// <param name="blockNumber">The block number</param>
        /// <returns>List of events associated to this block</returns>
        [HttpGet("{blockNumber}/events")]
        [Produces(typeof(IEnumerable<EventDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return events linked to given block")]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsAsync(uint blockNumber)
        {
            return await SendAndHandleResponseAsync(new EventsQuery()
            {
                BlockNumber = blockNumber
            });
        }

        /// <summary>
        /// Return logs link to given block
        /// </summary>
        /// <param name="blockNumber">The block number</param>
        /// <returns>List of logs associated to this block</returns>
        [HttpGet("{blockNumber}/logs")]
        [Produces(typeof(IEnumerable<LogDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return logs link to given block")]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogsAsync(uint blockNumber)
        {
            return await SendAndHandleResponseAsync(new LogsQuery()
            {
                BlockNumber = blockNumber
            });
        }

        /// <summary>
        /// Return an extrinsic link to given block and extrinsic index
        /// </summary>
        /// <param name="blockNumber">The block number</param>
        /// <param name="extrinsicIndex">The extrinsic index</param>
        /// <returns>Extrinsic details</returns>
        [HttpGet("extrinsic/{blockNumber}/{extrinsicIndex}")]
        [Produces(typeof(ExtrinsicDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return an extrinsic link to given block and extrinsic index")]
        public async Task<ActionResult<ExtrinsicDto>> GetExtrinsicDetailAsync(uint blockNumber, uint extrinsicIndex)
        {
            return await SendAndHandleResponseAsync(new ExtrinsicDetailQuery()
            {
                BlockNumber = blockNumber,
                ExtrinsicIndex = extrinsicIndex
            });
        }

        /// <summary>
        /// Return an event link to given block and event index
        /// </summary>
        /// <param name="blockNumber">The block number</param>
        /// <param name="eventIndex">The event index</param>
        /// <returns>The event details</returns>
        [HttpGet("event/{blockNumber}/{eventIndex}")]
        [Produces(typeof(EventDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return an event link to given block and event index")]
        public async Task<ActionResult<EventDto>> GetEventDetailAsync(uint blockNumber, uint eventIndex)
        {
            return await SendAndHandleResponseAsync(new EventDetailQuery()
            {
                BlockNumber = blockNumber,
                EventIndex = eventIndex
            });
        }
    }
}
