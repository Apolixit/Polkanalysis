using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Block
{
    public class BlockDetailsQuery : IRequest<Result<BlockDto, ErrorResult>>
    {
        public uint? BlockNumber { get; }
        public string? BlockHash { get; }

        public BlockDetailsQuery(uint blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public BlockDetailsQuery(string blockHash)
        {
            BlockHash = blockHash;
        }

        [JsonIgnore]
        public bool IsSet => BlockNumber != null && BlockHash != null;
    }
}
