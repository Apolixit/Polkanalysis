using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Balances
{
    public class ReserveData
    {
        public required string Id { get; set; }
        public BigInteger Amount { get; set; } = BigInteger.Zero;
    }
}
