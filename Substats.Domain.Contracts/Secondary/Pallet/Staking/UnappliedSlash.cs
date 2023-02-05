using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class UnappliedSlash
    {
        public SubstrateAccount Validator { get; set; }
        public BigInteger Own { get; set; } = BigInteger.Zero;
        public IEnumerable<IndividualExposure> Others { get; set; } = Enumerable.Empty<IndividualExposure>();
        public SubstrateAccount Reporters { get; set; }
        public BigInteger Payout { get; set; } = BigInteger.Zero;
    }
}
