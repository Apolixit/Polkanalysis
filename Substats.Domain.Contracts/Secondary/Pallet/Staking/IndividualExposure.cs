using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class IndividualExposure
    {
        public SubstrateAccount Who { get; set; }
        public U128 Value { get; set; } = new U128().With(BigInteger.Zero);
    }
}
