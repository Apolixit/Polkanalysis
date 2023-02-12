using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
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
        public U32 AuthorityIndex { get; set; }
        public U64 Slot { get; set; }
        public Hash VrfOutput { get; set; }
        public Hash VrfProof { get; set; }
        //public Hash64 VrfProof { get; set; }
    }
}
