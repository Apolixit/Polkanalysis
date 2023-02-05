using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class SlashingSpans
    {
        public uint SpanIndex { get; set; }
        public uint LastStart { get; set; }
        public uint LastNonzeroSlash { get; set; }
        public IEnumerable<uint> Prior { get; set; } = Enumerable.Empty<uint>();

    }
}
