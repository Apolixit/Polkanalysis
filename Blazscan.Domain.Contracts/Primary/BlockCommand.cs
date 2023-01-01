using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Primary
{
    /// <summary>
    /// Represent a request to get detail from a block
    /// </summary>
    public class BlockCommand
    {
        public uint? BlockNumber { get; }

        public BlockCommand(uint? blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public string? BlockHash { get; }

        public BlockCommand(string? blockHash)
        {
            BlockHash = blockHash;
        }
    }
}
