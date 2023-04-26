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

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountDetailUseCase : UseCase<AccountDetailUseCase, AccountDto, AccountCommand>
    {
        public AccountDetailUseCase(ILogger<AccountDetailUseCase> logger) : base(logger)
        {
        }

        public async override Task<Result<AccountDto, ErrorResult>> Handle(AccountCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            //var accountDto = new AccountDto("", "", "");

            //return await Task.Run(() => Helpers.Ok(accountDto));
            return null;
        }
    }
}
