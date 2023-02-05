using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class SubsOfResult
    {
        public required BigInteger Number { get; set; } = BigInteger.Zero;
        public required IEnumerable<SubstrateAccount> Accounts { get; set; }
    }
}
