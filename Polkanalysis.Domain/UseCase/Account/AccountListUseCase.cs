﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountListUseCase : UseCase<AccountListUseCase, IEnumerable<AccountListDto>, AccountListQuery>
    {
        private readonly IAccountRepository _accountRepository;
        public AccountListUseCase(IAccountRepository accountRepository, ILogger<AccountListUseCase> logger) : base(logger)
        {
            _accountRepository = accountRepository;
        }

        public async override Task<Result<IEnumerable<AccountListDto>, ErrorResult>> Handle(AccountListQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var res = await _accountRepository.GetAccountsAsync(cancellationToken);
            return Helpers.Ok(res);
        }
    }
}
