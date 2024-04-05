using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class SpanRecord : BaseType
    {
        public U128 Slashed { get; set; }
        public U128 PaidOut { get; set; }

        public SpanRecord() { }

        public SpanRecord(U128 slashed, U128 paidOut)
        {
            Create(slashed, paidOut);
        }

        public void Create(U128 slashed, U128 paidOut)
        {
            Slashed = slashed;
            PaidOut = paidOut;

            Bytes = Encode();
            TypeSize = Slashed.TypeSize + PaidOut.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Slashed.Encode());
            result.AddRange(PaidOut.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Slashed = new U128();
            Slashed.Decode(byteArray, ref p);
            PaidOut = new U128();
            PaidOut.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

    }
}
