using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Stats
{
    public class BlockchainInformationDto
    {
        public required string Name { get; set; }
        public required string FullName { get; set; }
        public required string Currency { get; set; }
        public required string ChainType { get; set; }
        public string? Website { get; set; }
        public string? Whitepaper { get; set; }
        public string? Twitter { get; set; }
        public string? Telegram { get; set; }
        public string? Founder { get; set; }
        public string? LogoUrl { get; set; }
        public string? Github { get; set; }
    }
}
