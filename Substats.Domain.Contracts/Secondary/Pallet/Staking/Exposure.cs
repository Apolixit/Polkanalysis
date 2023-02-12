using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class Exposure
    {
        public U128 Total { get; set; } = new U128().With(BigInteger.Zero);
        public U128 Own { get; set; } = new U128().With(BigInteger.Zero);
        public IEnumerable<IndividualExposure> Others { get; set; } = Enumerable.Empty<IndividualExposure>();
    }
}
