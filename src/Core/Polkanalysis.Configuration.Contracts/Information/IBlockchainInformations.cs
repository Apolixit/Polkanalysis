using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts.Information
{
    public interface IBlockchainInformations
    {
        public List<RelayChain> RelayChains { get; init; }
    }
}
