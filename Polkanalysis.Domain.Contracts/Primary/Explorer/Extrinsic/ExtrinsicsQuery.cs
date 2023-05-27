using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic
{
    public class ExtrinsicsQuery : IRequest<Result<IEnumerable<ExtrinsicDto>, ErrorResult>>
    {
        public uint BlockNumber { get; set; }
    }
}
