using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary
{
    public class BlockLightCommand : IRequest<Result<BlockLightDto, ErrorResult>>
    {
        public uint? BlockNumber { get; }
        public string? BlockHash { get; }

        public BlockLightCommand() { }

        public BlockLightCommand(uint blockNumber)
        {
            BlockNumber = blockNumber;
        }
        
        public BlockLightCommand(string blockHash)
        {
            BlockHash = blockHash;
        }

        public bool IsSet => BlockNumber != null && BlockHash != null;
    }

    public class BlockDetailsCommand : BlockCommand, IRequest<Result<BlockDto, ErrorResult>>
    {
        public BlockDetailsCommand(uint blockNumber) : base(blockNumber) { }

        public BlockDetailsCommand(string blockHash) : base(blockHash) { }
    }

    /// <summary>
    /// Represent a request to get detail from a block
    /// </summary>
    public abstract class BlockCommand : IRequest<Result<BlockDto, ErrorResult>>
    {
        public uint? BlockNumber { get; }
        public string? BlockHash { get; }

        protected BlockCommand(uint blockNumber)
        {
            BlockNumber = blockNumber;
        }

        protected BlockCommand(string blockHash)
        {
            BlockHash = blockHash;
        }
    }
}
