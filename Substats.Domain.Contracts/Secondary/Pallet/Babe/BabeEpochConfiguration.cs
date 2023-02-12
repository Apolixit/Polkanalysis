using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class BabeEpochConfiguration
    {
        public (U64, U64) c { get; set; }
        public EnumAllowedSlots AllowedSlots { get; set; }
    }
}
