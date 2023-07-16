using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Refined
{
    public class PalletConstantV9
    {
        public string Name { get; init; }
        public uint TypeId { get; init; }
        public byte[] Value { get; init; }
        public string[] Docs { get; init; }
    }
}
