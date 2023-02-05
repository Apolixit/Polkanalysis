using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Balances
{
    public class BalanceLock
    {
        public required string Id { get; set; }
        public BigInteger Amount { get; set; } = BigInteger.Zero;
        public required ReasonType Reason { get; set; }

        public enum ReasonType
        {
            Fee = 0,
            Misc = 1,
            All = 2,
        }
    }
}
