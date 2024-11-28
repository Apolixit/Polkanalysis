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
    public class AccountFinancialTransactionsQuery : IRequest<Result<AccountFinancialTransactionsDto, ErrorResult>>, ICached
    {
        protected AccountFinancialTransactionsQuery()
        {
            AccountAddress = string.Empty;
            RangeDate = RangeDate.Default;
            Pagination = Pagination.Default;
        }

        public AccountFinancialTransactionsQuery(string accountAddress, DateTime? from, DateTime? to) : this()
        {
            AccountAddress = accountAddress;
            RangeDate = new RangeDate(from, to);
        }

        public AccountFinancialTransactionsQuery(string accountAddress, DateTime? from, DateTime? to, int pageSize, int pageNumber) : this(accountAddress, from, to)
        {
            Pagination = new Pagination(pageSize, pageNumber);
        }

        public string AccountAddress { get; set; }
        public RangeDate RangeDate { get; set; }
        public Pagination Pagination { get; set; }

        public int CacheDurationInMinutes => Constants.Cache.MediumCache;

        public string GenerateCacheKey()
            => $"{nameof(AccountFinancialTransactionsQuery)}_{AccountAddress}_{(RangeDate.From is not null ? RangeDate.From.Value.ToString("dd.MM.yyyy") : "0")}_{(RangeDate.To is not null ? RangeDate.To.Value.ToString("dd.MM.yyyy") : "0")}";
    }
}
