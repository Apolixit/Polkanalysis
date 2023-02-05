using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class SpanRecord
    {
        public BigInteger Slashed { get; set; } = BigInteger.Zero;
        public BigInteger PaidOut { get; set; } = BigInteger.Zero;

    }
}
