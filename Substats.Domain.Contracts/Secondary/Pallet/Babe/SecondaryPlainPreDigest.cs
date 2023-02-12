using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class SecondaryPlainPreDigest
    {
        public U32 AuthorityIndex { get; set; }
        public U64 Slot { get; set; }

    }
}
