using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class RewardPool
    {
        public U128 LastRecordedRewardCounter { get; set; } = new U128().With(BigInteger.Zero);
        public U128 LastRecordedTotalPayouts { get; set; } = new U128().With(BigInteger.Zero);
        public U128 TotalRewardsClaimed { get; set; } = new U128().With(BigInteger.Zero);
    }
}
