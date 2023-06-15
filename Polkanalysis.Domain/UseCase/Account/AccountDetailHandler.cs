using Polkanalysis.Domain.Contracts.Primary;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountDetailHandler : Handler<AccountDetailHandler, AccountDto, AccountDetailQuery>
    {
        private readonly IAccountService _accountRepository;
        public AccountDetailHandler(IAccountService accountRepository, ILogger<AccountDetailHandler> logger) : base(logger)
        {
            _accountRepository = accountRepository;
        }

        public async override Task<Result<AccountDto, ErrorResult>> Handle(AccountDetailQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var res = await _accountRepository.GetAccountDetailAsync(request.AccountAddress, cancellationToken);
            return Helpers.Ok(res);
        }
    }
}
