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
    public class PoolMember
    {
        public U32 PoolId { get; set; }
        public U128 Points { get; set; } = new U128().With(BigInteger.Zero);
        public U128 LastRecordedRewardCounter { get; set; } = new U128().With(BigInteger.Zero);

        /// <summary>
        /// https://docs.rs/pallet-nomination-pools/latest/pallet_nomination_pools/struct.PoolMember.html
        /// IDictionnary<EraIndex, Balance>
        /// </summary>
        public IDictionary<U32, U128> UnbondingEras { get; set; } = new Dictionary<U32, U128>();

    }
}
