using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Monitored.Extrinsics
{
    public record SavedExtrinsicsCommand(uint BlockNumber) : IRequest<Result<bool, ErrorResult>>
    {
    }
}
