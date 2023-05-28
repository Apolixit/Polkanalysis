using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Crowdloan;
using Polkanalysis.Domain.Contracts.Primary.Parachain;

namespace Polkanalysis.Api.Controllers
{
    public class AccountController : MasterController
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator, ILogger<AccountController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<AccountListDto>))]
        public async Task<ActionResult<IEnumerable<AccountListDto>>> GetAccountsAsync()
        {
            return await SendAndHandleResponseAsync(new AccountListQuery());
        }

        [HttpGet("{address}")]
        [Produces(typeof(AccountDto))]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new AccountDetailQuery() { 
                AccountAddress = address 
            });
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
    }
}
