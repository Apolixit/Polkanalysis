﻿using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary
{
    public class AccountCommand : IRequest<Result<AccountDto, ErrorResult>>
    {
        public string? AccountAddress { get; set; }
    }
}
