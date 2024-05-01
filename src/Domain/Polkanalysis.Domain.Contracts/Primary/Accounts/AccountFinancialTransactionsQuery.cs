using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Accounts
{
    public class AccountFinancialTransactionsQuery : IRequest<Result<AccountFinancialTransactionsDto, ErrorResult>>
    {
        public AccountFinancialTransactionsQuery(string accountAddress, DateTime? from, DateTime? to)
        {
            AccountAddress = accountAddress;
            From = from;
            To = to;
        }

        public AccountFinancialTransactionsQuery(string accountAddress, DateTime? from, DateTime? to, int pageSize, int pageNumber) : this(accountAddress, from, to)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public string AccountAddress { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int PageSize { get; set; } = Constants.DefaultPageSize;
        public int PageNumber { get; set; } = Constants.DefaultPageNumber;
    }
}
