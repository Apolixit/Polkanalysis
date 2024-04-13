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
    public class SpecVersionsQuery : IRequest<Result<IEnumerable<SpecVersionDto>, ErrorResult>>
    {
        public uint? SpecVersionNumber { get; set; }
        public string? BlockchainName { get; set; }
    }
}
