using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Era;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Dto.Staking.Reward;
using Polkanalysis.Domain.Contracts.Dto.Staking.Validator;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Primary.Staking.Nominators;
using Polkanalysis.Domain.Contracts.Primary.Staking.Pools;
using Polkanalysis.Domain.Contracts.Primary.Staking.Rewards;
using Polkanalysis.Domain.Contracts.Primary.Staking.Validators;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class StakingController : MasterController
    {
        /* TODO : add era as parameter to allow query in the past
         * [HttpGet("{eraId}/validators/{address}/nominators")]
         * [HttpGet("{eraId}/validators")]
         */
        public StakingController(IMediator mediator, ILogger<StakingController> logger) : base(mediator, logger)
        {
        }

        [HttpGet("era")]
        [Produces(typeof(CurrentEraDto))]
        [Description("Get current era general informations")]
        public async Task<ActionResult<CurrentEraDto>> GetCurrentEraAsync()
        {
            return await SendAndHandleResponseAsync(new CurrentEraInformationQuery());
        }

        [HttpGet("validators")]
        [Produces(typeof(IEnumerable<ValidatorLightDto>))]
        [Description("Get active validators for current era")]
        public async Task<ActionResult<IEnumerable<ValidatorLightDto>>> GetValidatorsAsync()
        {
            return await SendAndHandleResponseAsync(new ValidatorsQuery());
        }

        [HttpGet("validators/{address}")]
        [Produces(typeof(ValidatorDto))]
        [Description("Get active validator for current era by given validator address")]
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
        [Description("Get nominators who voted for given validator for current era")]
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
        [Description("Get eras information when given validator was active")]
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
        [Description("Get rewards history for given validator")]
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
        [Description("Get nominators for current era")]
        public async Task<ActionResult<IEnumerable<NominatorLightDto>>> GetNominatorsAsync()
        {
            return await SendAndHandleResponseAsync(new NominatorsQuery());
        }

        [HttpGet("nominators/{address}")]
        [Produces(typeof(NominatorDto))]
        [Description("Get nominator with given address for current era")]
        public async Task<ActionResult<NominatorDto>> GetNominatorsAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new NominatorDetailQuery()
            {
                NominatorAddress = address
            });
        }

        [HttpGet("nominators/{nominatorAddress}/votes")]
        [Produces(typeof(IEnumerable<ValidatorLightDto>))]
        [Description("Get validators voted by given nominator address for current era")]
        public async Task<ActionResult<IEnumerable<ValidatorLightDto>>> GetValidatorsElectedByNominatorAsync(string nominatorAddress)
        {
            return await SendAndHandleResponseAsync(new ValidatorsQuery()
            {
                ElectedByNominator = nominatorAddress
            });
        }

        [HttpGet("pools")]
        [Produces(typeof(IEnumerable<PoolLightDto>))]
        [Description("Get nomination pool (active and inactive)")]
        public async Task<ActionResult<IEnumerable<PoolLightDto>>> GetPoolsAsync()
        {
            return await SendAndHandleResponseAsync(new PoolsQuery());
        }

        [HttpGet("pools/{poolId}")]
        [Produces(typeof(PoolDto))]
        [Description("Get nomination pool for given pool Id")]
        public async Task<ActionResult<PoolDto>> GetPoolsAsync(uint poolId)
        {
            return await SendAndHandleResponseAsync(new PoolDetailQuery() { 
                poolId = poolId 
            });
        }
    }
}
