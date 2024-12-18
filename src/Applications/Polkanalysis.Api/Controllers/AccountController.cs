using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Settings;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    /// <summary>
    /// Fetch informations about Substrate accounts
    /// </summary>
    [Produces("application/json")]
    public class AccountController : MasterController
    {
        /// <summary>
        /// Default <see cref="AccountController" /> constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public AccountController(IMediator mediator, ILogger<AccountController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Return blockchain accounts
        /// </summary>
        /// <param name="size">Number of items returned</param>
        /// <param name="page">Page number</param>
        /// <returns>List of accounts with <see cref="AccountLightDto" /> info</returns>
        /// <response code="200">Returns data</response>
        /// <response code="400">An error happened in the backend</response>
        [HttpGet(Name = "accounts")]
        [Produces(typeof(IEnumerable<AccountLightDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return blockchain accounts")]
        public async Task<ActionResult<PagedResponseDto<AccountLightDto>>> GetAccountsAsync(
            int size = ConstantsPagination.DefaultPageSize, 
            int page = ConstantsPagination.DefaultPageNumber)
        {
            return await SendAndHandleResponseAsync(new AccountsQuery(size, page));
        }

        /// <summary>
        /// Retrieve account by his Substrate address
        /// </summary>
        /// <param name="address">The address account to get data</param>
        /// <returns>The account details</returns>
        /// <response code="200">Returns data</response>
        /// <response code="400">An error happened in the backend</response>
        [HttpGet("{address}")]
        [Produces(typeof(AccountDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Retrieve account by his Substrate address")]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(string address)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new AccountDetailQuery() { 
                AccountAddress = address 
            });
        }

        /// <summary>
        /// Get account transactions related to this Substrate address
        /// </summary>
        /// <param name="address">The address to check the transactions</param>
        /// <param name="from">Start date</param>
        /// <param name="to">End date</param>
        /// <param name="size">Number of items returned</param>
        /// <param name="page">Page number</param>
        /// <returns>The account list of transaction during the selected period</returns>
        /// <response code="200">Returns data</response>
        /// <response code="400">An error happened in the backend</response>
        /// <remarks>
        /// Example request :
        ///     GET /131Y21vAVYxm7f5xtaV3NydJRpig3CqyvjTyFM8gMpRbFH1T/transactions
        /// </remarks>
        [HttpGet("{address}/transactions")]
        [Produces(typeof(AccountFinancialTransactionsDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Get account transactions related to this Substrate address")]
        public async Task<ActionResult<AccountFinancialTransactionsDto>> GetAccountTransactionsAsync(string address, DateTime? from, DateTime? to, int size = 20, int page = 1)
        {
            if (string.IsNullOrEmpty(address)) return BadRequest();

            return await SendAndHandleResponseAsync(new AccountFinancialTransactionsQuery(address, from, to, size, page));
        }
    }
}
