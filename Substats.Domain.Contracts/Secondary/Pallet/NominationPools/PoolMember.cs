using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class PoolMember
    {
        public uint PoolId { get; set; }
        public BigInteger Points { get; set; } = BigInteger.Zero;
        public BigInteger LastRecordedRewardCounter { get; set; } = BigInteger.Zero;

        /// <summary>
        /// https://docs.rs/pallet-nomination-pools/latest/pallet_nomination_pools/struct.PoolMember.html
        /// IDictionnary<EraIndex, Balance>
        /// </summary>
        public IDictionary<uint, BigInteger> UnbondingEras { get; set; } = new Dictionary<uint, BigInteger>();

    }
}
