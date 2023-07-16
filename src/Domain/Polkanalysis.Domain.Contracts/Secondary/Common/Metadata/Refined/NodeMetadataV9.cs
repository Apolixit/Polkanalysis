using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class NodeMetadataV9
    {
        public required Dictionary<uint, PalletModuleV9> Modules { get; set; }
        public uint TypeId { get; }
    }
}
