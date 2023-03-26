using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Primary
{
    /// <summary>
    /// Represent a request to get detail from a block
    /// </summary>
    public class BlockCommand
    {
        public uint? BlockNumber { get; }
        public string? BlockHash { get; }

        public BlockCommand(uint blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public BlockCommand(string blockHash)
        {
            BlockHash = blockHash;
        }
    }
}
