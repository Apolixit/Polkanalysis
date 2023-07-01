using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Statistics
{
    public class BlockchainInformationQuery : IRequest<Result<BlockchainInformationDto, ErrorResult>>
    {
    }
}
