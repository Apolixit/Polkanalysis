using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class RewardPool
    {
        public BigInteger LastRecordedRewardCounter { get; set; } = BigInteger.Zero;
        public BigInteger LastRecordedTotalPayouts { get; set; } = BigInteger.Zero;
        public BigInteger TotalRewardsClaimed { get; set; } = BigInteger.Zero;
    }
}
