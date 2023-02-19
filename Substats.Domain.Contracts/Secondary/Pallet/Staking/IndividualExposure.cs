using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class IndividualExposure : BaseType
    {
        public SubstrateAccount Who { get; set; }
        public U128 Value { get; set; } = new U128().With(BigInteger.Zero);

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new SubstrateAccount();
            Who.Decode(byteArray, ref p);
            Value = new U128();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
