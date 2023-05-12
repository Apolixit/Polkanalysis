using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Polkanalysis.Api.Controllers
{
    public class AccountController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountsAsync()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{address}")]
        public async Task<IActionResult> GetAccountAsync(string address)
        {
            throw new NotImplementedException();
        }
    }
}
