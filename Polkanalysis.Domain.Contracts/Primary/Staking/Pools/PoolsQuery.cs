﻿using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Staking.Pool;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Pools
{
    public class PoolsQuery : IRequest<Result<IEnumerable<PoolLightDto>, ErrorResult>>
    {
    }
}
