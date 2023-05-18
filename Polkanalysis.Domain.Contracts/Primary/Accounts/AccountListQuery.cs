﻿using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Accounts
{
    public class AccountListQuery : IRequest<Result<IEnumerable<AccountListDto>, ErrorResult>>
    {
        public AccountType? AccountRole { get; set; }
    }
}
