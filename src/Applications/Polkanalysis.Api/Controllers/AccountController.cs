using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class AccountController : MasterController
    {
        public AccountController(IMediator mediator, ILogger<AccountController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<AccountLightDto>))]
        [Description("Return blockchain accounts")]
        public async Task<ActionResult<PagedResponseDto<AccountLightDto>>> GetAccountsAsync(int size = 20, int page = 1)
        {
            return await SendAndHandleResponseAsync(new AccountsQuery()
            {
                PageSize = size,
                PageNumber = page
            });
        }

        [HttpGet("{address}")]
        [Produces(typeof(AccountDto))]
        [Description("Retrieve account by his Substrate address")]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new AccountDetailQuery() { 
                AccountAddress = address 
            });
        }

        [HttpGet("{address}/transactions")]
        [Produces(typeof(AccountFinancialTransactionsDto))]
        [Description("Get account transactions related to this Substrate address")]
        public async Task<ActionResult<AccountFinancialTransactionsDto>> GetAccountTransactionsAsync(string address, DateTime? from, DateTime? to, int size = 20, int page = 1)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new AccountFinancialTransactionsQuery(address, from, to, size, page));
        }
    }
}
