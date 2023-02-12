using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Crowdloan
{
    public class FundInfo
    {
        public required SubstrateAccount Depositor { get; set; }
        public EnumMultiSigner? Verifier { get; set; }
        public U128 Deposit { get; set; } = new U128().With(BigInteger.Zero);
        public U128 Raised { get; set; } = new U128().With(BigInteger.Zero);
        public U32 End { get; set; }
        public U128 Cap { get; set; } = new U128().With(BigInteger.Zero);
        public EnumLastContribution? LastContribution { get; set; }
        public U32 FirstPeriod { get; set; }
        public U32 LastPeriod { get; set; }
        public U32 FundIndex { get; set; }
    }
}
