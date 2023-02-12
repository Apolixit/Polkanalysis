using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class SlashingSpans
    {
        public U32 SpanIndex { get; set; }
        public U32 LastStart { get; set; }
        public U32 LastNonzeroSlash { get; set; }
        public IEnumerable<U32> Prior { get; set; } = Enumerable.Empty<U32>();

    }
}
