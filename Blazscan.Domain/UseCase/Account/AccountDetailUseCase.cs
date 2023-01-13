﻿using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Primary;
using Microsoft.Extensions.Logging;
using OperationResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.UseCase.Account
{
    public class AccountDetailUseCase : UseCase<AccountDetailUseCase, AccountDto, AccountCommand>
    {
        public AccountDetailUseCase(ILogger<AccountDetailUseCase> logger) : base(logger)
        {
        }

        public async override Task<Result<AccountDto, ErrorResult>> ExecuteAsync(AccountCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            var accountDto = new AccountDto("", "", "");

            return await Task.Run(() => Helpers.Ok(accountDto));
        }
    }
}
