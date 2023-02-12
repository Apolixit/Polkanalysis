
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class UnlockChunk
    {
        public U128 Value { get; set; } = new U128().With(BigInteger.Zero);
        public U32 Era { get; set; }
    }
}
