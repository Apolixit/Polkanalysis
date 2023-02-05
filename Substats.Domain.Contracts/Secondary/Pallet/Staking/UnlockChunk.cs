using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class UnlockChunk
    {
        public BigInteger Value { get; set; } = BigInteger.Zero;
        public uint Era { get; set; }
    }
}
