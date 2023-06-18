using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Primary.Staking.Rewards;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;

namespace Polkanalysis.Api.Controllers
{
    public class StakingController : MasterController
    {
        private readonly ILogger<StakingController> _logger;

        public StakingController(IMediator mediator, ILogger<StakingController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet("validators")]
        [Produces(typeof(IEnumerable<ValidatorLightDto>))]
        public async Task<ActionResult<IEnumerable<ValidatorLightDto>>> GetValidatorsAsync()
        {
            return await SendAndHandleResponseAsync(new ValidatorsQuery());
        }

        [HttpGet("validators/{address}")]
        [Produces(typeof(ValidatorDto))]
        public async Task<ActionResult<ValidatorDto>> GetValidatorsAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new ValidatorDetailQuery()
            {
                ValidatorAddress = address
            });
        }

        [HttpGet("validators/{address}/nominators")]
        [Produces(typeof(IEnumerable<NominatorLightDto>))]
        public async Task<ActionResult<IEnumerable<NominatorLightDto>>> GetValidatorNominatorsAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new NominatorsQuery()
            {
                ValidatorAddress = address
            });
        }

        [HttpGet("validators/{address}/eras")]
        [Produces(typeof(IEnumerable<EraLightDto>))]
        public async Task<ActionResult<IEnumerable<EraLightDto>>> GetValidatorErasAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new ErasQuery()
            {
                ValidatorAddress = address
            });
        }

        [HttpGet("validators/{address}/rewards")]
        [Produces(typeof(IEnumerable<RewardDto>))]
        public async Task<ActionResult<IEnumerable<RewardDto>>> GetValidatorRewardsAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new RewardsQuery()
            {
                ValidatorAddress = address
            });
        }

        [HttpGet("nominators")]
        [Produces(typeof(IEnumerable<NominatorLightDto>))]
        public async Task<ActionResult<IEnumerable<NominatorLightDto>>> GetNominatorsAsync()
        {
            return await SendAndHandleResponseAsync(new NominatorsQuery());
        }

        [HttpGet("nominators/{address}")]
        [Produces(typeof(NominatorDto))]
        public async Task<ActionResult<NominatorDto>> GetNominatorsAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new NominatorDetailQuery()
            {
                NominatorAddress = address
            });
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
