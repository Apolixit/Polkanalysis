using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class StakingLedger
    {
        public required SubstrateAccount Stash { get; set; }
        public BigInteger Total { get; set; } = BigInteger.Zero;
        public BigInteger Active { get; set; } = BigInteger.Zero;
        public IEnumerable<UnlockChunk> Unlocking { get; set; } = Enumerable.Empty<UnlockChunk>();
        public IEnumerable<uint> ClaimedRewards { get; set; } = new List<uint>();

    }
}
