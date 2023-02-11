using Substats.Domain.Contracts.Core.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class SecondaryVRFPreDigest
    {
        public uint AuthorityIndex { get; set; }
        public ulong Slot { get; set; }
        public Hash VrfOutput { get; set; }
        public Hash64 VrfProof { get; set; }
    }
}
