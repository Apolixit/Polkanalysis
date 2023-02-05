using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class BondedPoolInner
    {
        public BigInteger Points { get; set; } = BigInteger.Zero;
        public PoolState State { get; set; }
        public uint MemberCounter { get; set; }
        public PoolRoles Roles { get; set; } = new PoolRoles();
    }
}
