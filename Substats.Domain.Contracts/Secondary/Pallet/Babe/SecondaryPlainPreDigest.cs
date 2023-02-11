using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class SecondaryPlainPreDigest
    {
        public uint AuthorityIndex { get; set; }
        public ulong Slot { get; set; }

    }
}
