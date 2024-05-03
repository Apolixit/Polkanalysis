using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
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
            RangeDate = new RangeDate(from, to);
        }

        public AccountFinancialTransactionsQuery(string accountAddress, DateTime? from, DateTime? to, int pageSize, int pageNumber) : this(accountAddress, from, to)
        {
            Pagination = new Pagination(pageSize, pageNumber);
        }

        public string AccountAddress { get; set; }
        public RangeDate RangeDate { get; set; } = new RangeDate();
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
