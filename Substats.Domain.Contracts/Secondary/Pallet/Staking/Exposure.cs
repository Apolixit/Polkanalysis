using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.AjunaExtension.Encoding;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Staking
{
    public class Exposure : BaseType
    {
        public U128 Total { get; set; } = new U128().With(BigInteger.Zero);
        public U128 Own { get; set; } = new U128().With(BigInteger.Zero);
        public IEnumerable<IndividualExposure> Others { get; set; } = Enumerable.Empty<IndividualExposure>();

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Own.Encode());
            result.AddRange(EnumerableEncodingHelper.Encode(Others));
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new U128();
            Total.Decode(byteArray, ref p);
            Own = new U128();
            Own.Decode(byteArray, ref p);

            Others = EnumerableEncodingHelper.Decode<IndividualExposure>(byteArray, p);
            TypeSize = p - start;
        }
    }
}
