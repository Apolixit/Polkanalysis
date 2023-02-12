using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class BondedPoolInner
    {
        public U128 Points { get; set; } = new U128().With(BigInteger.Zero);
        public PoolState State { get; set; }
        public U32 MemberCounter { get; set; }
        public PoolRoles Roles { get; set; } = new PoolRoles();
    }
}
