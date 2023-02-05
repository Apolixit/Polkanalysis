using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class IndividualExposure
    {
        public SubstrateAccount Who { get; set; }
        public BigInteger Value { get; set; } = BigInteger.Zero; 
    }
}
