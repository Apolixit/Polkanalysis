﻿using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.RuntimeModule
{
    public class RuntimeModulesQuery : IRequest<Result<IEnumerable<ModuleDetailDto>, ErrorResult>>
    {
        public uint? runtimeId { get; set; }
    }
}
