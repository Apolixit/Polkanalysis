using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto;
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
    public class AccountsQuery : IRequest<Result<PagedResponseDto<AccountLightDto>, ErrorResult>>
    {
        public AccountsQuery() {
            Pagination = Pagination.Default;
        }

        public AccountsQuery(int pageSize, int pageNumber) : this()
        {
            Pagination = new Pagination(pageSize, pageNumber);
        }

        public AccountType? AccountRole { get; set; }
        public Pagination Pagination { get; set; }
    }
}
