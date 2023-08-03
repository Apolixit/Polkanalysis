using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion
{
    public class SpecVersionCommand : IRequest<Result<bool, ErrorResult>>
    {
        public uint SpecVersion { get; set; }
        public uint BlockStart { get; set; }
    }
}
