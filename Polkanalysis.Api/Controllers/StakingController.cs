using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Polkanalysis.Domain.Contracts.Dto.Staking;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;

namespace Polkanalysis.Api.Controllers
{
    public class StakingController : MasterController
    {
        private readonly ILogger<StakingController> _logger;

        public StakingController(IMediator mediator, ILogger<StakingController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("pools")]
        [Produces(typeof(IEnumerable<PoolLightDto>))]
        public async Task<ActionResult<IEnumerable<PoolLightDto>>> GetPoolsAsync()
        {
            return await SendAndHandleResponseAsync(new PoolsQuery());
        }

        [HttpGet("pools/{poolId}")]
        [Produces(typeof(PoolDto))]
        public async Task<ActionResult<PoolDto>> GetPoolsAsync(uint poolId)
        {
            return await SendAndHandleResponseAsync(new PoolDetailQuery() { 
                poolId = poolId 
            });
        }
    }
}
