﻿using FluentValidation;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Balances;
using Polkanalysis.Domain.Contracts.Dto.Financial;
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

        /// <summary>
        /// Big use case : 5CuVA2rBdwhZr2aSbg6t81KxANxdjt6Ls9zNAYDEFs3Mx16N
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task<Result<AccountFinancialTransactionsDto, ErrorResult>> Handle(AccountFinancialTransactionsQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            var transactions = await _financialService.GetAccountTransactionsAsync(new SubstrateAccount(request.AccountAddress), request.From, request.To, cancellationToken);

            var filteredTransactions = transactions.OrderByDescending(x => x.BlockNumber).Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

            var accountAddress = await _accountService.GetAccountAddressAsync(request.AccountAddress, cancellationToken);
            var totalAmountReceived = filteredTransactions.Where(x  => x.GetTypeTransaction(request.AccountAddress) == Contracts.Dto.Financial.TransactionDto.TypeTransactionDto.Received).Sum(x => x.Amount.Native);
            var totalAmountSent = filteredTransactions.Where(x => x.GetTypeTransaction(request.AccountAddress) == Contracts.Dto.Financial.TransactionDto.TypeTransactionDto.Send).Sum(x => x.Amount.Native);

            var result = new AccountFinancialTransactionsDto(
                accountAddress,
                request.From,
                request.To,
                new CurrencyDto(totalAmountReceived, null),
                new CurrencyDto(totalAmountSent, null),
                new PagedResponseDto<TransactionDto>(filteredTransactions, request.PageNumber, request.PageSize, transactions.Count())
            );

            return Helpers.Ok(result);
        }
    }
}
