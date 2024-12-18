using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Service;
using FluentValidation;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountDetailValidator : AbstractValidator<AccountDetailQuery>
    {
        public AccountDetailValidator(ISubstrateService substrateService)
        {
            RuleFor(x => x.AccountAddress).Must(substrateService.IsValidAccountAddress);
        }
    }
    public class AccountDetailHandler : Handler<AccountDetailHandler, AccountDto, AccountDetailQuery>
    {
        private readonly IAccountService _accountRepository;
        public AccountDetailHandler(IAccountService accountRepository, ILogger<AccountDetailHandler> logger, HybridCache cache) : base(logger, cache)
        {
            _accountRepository = accountRepository;
        }

        public async override Task<Result<AccountDto, ErrorResult>> HandleInnerAsync(AccountDetailQuery request, CancellationToken cancellationToken)
        {
            var res = await _accountRepository.GetAccountDetailAsync(request.AccountAddress, cancellationToken);
            return Helpers.Ok(res);
        }
    }
}
