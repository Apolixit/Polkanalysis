using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Logs;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Logs
{
    public class LogsQuery : IRequest<Result<IEnumerable<LogDto>, ErrorResult>>
    {
        public uint BlockNumber { get; set; }
    }
}
