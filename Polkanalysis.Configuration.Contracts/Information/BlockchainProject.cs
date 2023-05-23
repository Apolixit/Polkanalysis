using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts.Information
{
    public class BlockchainProject
    {
        public string Name { get; set; } = string.Empty;
        public int? ParachainId { get; set; }
        public string? LogoUrl { get; set; }
        public string? Telegram { get; set; }
        public string? Founder { get; set; }
        public string? Twitter { get; set; }
        public string? Website { get; set; }
        public string? Whitepaper { get; set; }
        public string? Github { get; set; }
        public string? Medium { get; set; }
        public string? Discord { get; set; }
    }
}
