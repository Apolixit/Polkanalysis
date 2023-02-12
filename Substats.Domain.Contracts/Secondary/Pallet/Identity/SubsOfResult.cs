using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class SubsOfResult
    {
        public required U128 Number { get; set; } = new U128().With(BigInteger.Zero);
        public required IEnumerable<SubstrateAccount> Accounts { get; set; }
    }
}
