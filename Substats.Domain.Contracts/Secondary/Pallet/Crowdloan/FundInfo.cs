using Org.BouncyCastle.Math;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Crowdloan
{
    public class FundInfo
    {
        public required SubstrateAccount Depositor { get; set; }
        public EnumMultiSigner? Verifier { get; set; }
        public BigInteger Deposit { get; set; } = BigInteger.Zero;
        public BigInteger Raised { get; set; } = BigInteger.Zero;
        public uint End { get; set; }
        public BigInteger Cap { get; set; } = BigInteger.Zero;
        public EnumLastContribution? LastContribution { get; set; }
        public uint FirstPeriod { get; set; }
        public uint LastPeriod { get; set; }
        public uint FundIndex { get; set; }
    }
}
