using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using System.ComponentModel;

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
        [Produces(typeof(IEnumerable<AccountLightDto>))]
        [Description("Return blockchain accounts")]
        public async Task<ActionResult<IEnumerable<AccountLightDto>>> GetAccountsAsync()
        {
            return await SendAndHandleResponseAsync(new AccountsQuery());
        }

        [HttpGet("{address}")]
        [Produces(typeof(AccountDto))]
        [Description("Retrieve account by his Polkadot address")]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new AccountDetailQuery() { 
                AccountAddress = address 
            });
        }
    }
}
