using Substats.Domain.Contracts.Dto;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Primary
{
    public class EventCommand
    {
        public required uint BlockNumber { get; set; }
        public required uint EventIndex { get; set; }
    }
}
