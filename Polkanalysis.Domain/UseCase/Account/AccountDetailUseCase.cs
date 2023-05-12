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
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Accounts;

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountDetailUseCase : UseCase<AccountDetailUseCase, AccountDto, AccountDetailQuery>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountDetailUseCase(IAccountRepository accountRepository, ILogger<AccountDetailUseCase> logger) : base(logger)
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
