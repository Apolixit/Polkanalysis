using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp
{
    public interface IBlockData
    {
        IBlock GetBlock();
        object Justification { get; set; }
    }
}
