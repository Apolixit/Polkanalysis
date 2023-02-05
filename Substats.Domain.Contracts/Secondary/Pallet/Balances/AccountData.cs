using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Balances
{
    public class AccountData
    {
        public BigInteger Free { get; set; } = BigInteger.Zero;
        public BigInteger Reserved { get; set; } = BigInteger.Zero;
        public BigInteger MiscFrozen { get; set; } = BigInteger.Zero;
        public BigInteger FeeFrozen { get; set; } = BigInteger.Zero;

    }
}
