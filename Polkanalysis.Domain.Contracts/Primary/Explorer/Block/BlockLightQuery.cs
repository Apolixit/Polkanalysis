using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Block
{
    public class BlockLightQuery : IRequest<Result<BlockLightDto, ErrorResult>>
    {
        public uint? BlockNumber { get; }
        public string? BlockHash { get; }

        public BlockLightQuery() { }

        public BlockLightQuery(uint blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public BlockLightQuery(string blockHash)
        {
            BlockHash = blockHash;
        }

        public bool IsSet => BlockNumber != null || BlockHash != null;
    }
}
