using FluentValidation;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Account
{
    public class AccountFinancialTransactionsValidator : AbstractValidator<AccountFinancialTransactionsQuery>
    {
        public AccountFinancialTransactionsValidator(ISubstrateService substrateService)
        {
            RuleFor(x => x.AccountAddress).Must(substrateService.IsValidAccountAddress);
        }
    }
    public class AccountFinancialTransactionsHandler : Handler<AccountFinancialTransactionsHandler, AccountFinancialTransactionsDto, AccountFinancialTransactionsQuery>
    {
        private readonly IFinancialService _financialService;
        private readonly IAccountService _accountService;

        public AccountFinancialTransactionsHandler(ILogger<AccountFinancialTransactionsHandler> logger, IFinancialService financialService, IAccountService accountService) : base(logger)
        {
            _financialService = financialService;
            _accountService = accountService;
        }

        public async override Task<Result<AccountFinancialTransactionsDto, ErrorResult>> Handle(AccountFinancialTransactionsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var transactions = await _financialService.GetAccountTransactionsAsync(new SubstrateAccount(request.AccountAddress), request.From, request.To, cancellationToken);

            var accountAddress = await _accountService.GetAccountAddressAsync(request.AccountAddress, cancellationToken);
            var totalAmountReceived = transactions.Where(x  => x.GetTypeTransaction(request.AccountAddress) == Contracts.Dto.Financial.TransactionDto.TypeTransactionDto.Send).Sum(x => x.Amount.Native);
            var totalAmountSent = transactions.Where(x => x.GetTypeTransaction(request.AccountAddress) == Contracts.Dto.Financial.TransactionDto.TypeTransactionDto.Send).Sum(x => x.Amount.Native);

            var result = new AccountFinancialTransactionsDto(
                accountAddress,
                request.From,
                request.To,
                new CurrencyDto(totalAmountReceived, null),
                new CurrencyDto(totalAmountSent, null),
                transactions.ToList()
            );

            return Helpers.Ok(result);
        }
    }
}
