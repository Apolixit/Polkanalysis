using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class BabeEpochConfiguration
    {
        public (ulong, ulong) c { get; set; }
        public EnumAllowedSlots AllowedSlots { get; set; }
    }
}
