using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class SpanRecord
    {
        public U128 Slashed { get; set; } = new U128().With(BigInteger.Zero);
        public U128 PaidOut { get; set; } = new U128().With(BigInteger.Zero);

    }
}
