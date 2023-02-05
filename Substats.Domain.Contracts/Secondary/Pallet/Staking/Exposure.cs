using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class Exposure
    {
        public BigInteger Total { get; set; } = BigInteger.Zero;
        public BigInteger Own { get; set; } = BigInteger.Zero;
        public IEnumerable<IndividualExposure> Others { get; set; } = Enumerable.Empty<IndividualExposure>();
    }
}
