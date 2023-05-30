using Polkanalysis.Configuration.Contracts.Information;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Informations
{
    public class BlockchainDetailsDto
    {
        public required BlockchainProject BlockchainInformationDetail { get; set; }
        public string FullName { get; set; }
        public bool IsRelayChain { get; set; }
        public bool IsAlive { get; set; }
        public string TokenSymbol { get; set; } = string.Empty;
        public int TokenDecimal { get; set; }
        public string Version { get; set; } = string.Empty;
    }
}
