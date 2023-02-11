using Substats.Domain.Contracts.Core.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class EventRecord
    {
        public EnumPhase Phase { get; set; }
        public EnumRuntimeEvent Event { get; set; }
        public IEnumerable<Hash> Topics { get; set; } = Enumerable.Empty<Hash>();
    }
}
