using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class StakingLedger
    {
        public required SubstrateAccount Stash { get; set; }
        public U128 Total { get; set; } = new U128().With(BigInteger.Zero);
        public U128 Active { get; set; } = new U128().With(BigInteger.Zero);
        public IEnumerable<UnlockChunk> Unlocking { get; set; } = Enumerable.Empty<UnlockChunk>();
        public IEnumerable<U32> ClaimedRewards { get; set; } = new List<U32>();

    }
}
