using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts.Information
{
    public class RelayChain
    {
        public RelayChain(string relayChainName, IEnumerable<BlockchainProject> blockainInformations)
        {
            RelayChainName = relayChainName;
            BlockainInformations = blockainInformations;
        }

        public string RelayChainName { get; init; }
        public IEnumerable<BlockchainProject> BlockainInformations { get; init; }
    }
}
