using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Informations;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Informations
{
    public class BlockchainDetailsQuery : IRequest<Result<BlockchainDetailsDto, ErrorResult>>
    {
        public string? BlockchainName { get; set; }
    }
}
