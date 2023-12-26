using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping
{
    internal class ScanMappingResult
    {
        public string SourceClass { get; set; } = string.Empty;
        public string? DestinationClass { get; set; }
    }
}
