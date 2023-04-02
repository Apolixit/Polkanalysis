using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras
{
    public class ReplacementTimes : BaseType
    {
        public U32 ExpectedAt { get; set; }
        public U32 ActivatedAt { get; set; }

        public ReplacementTimes() { }

        public ReplacementTimes(U32 expectedAt, U32 activatedAt)
        {
            Create(expectedAt, activatedAt);
        }

        public void Create(U32 expectedAt, U32 activatedAt)
        {
            ExpectedAt = expectedAt;
            ActivatedAt = activatedAt;

            Bytes = Encode();
            TypeSize = ExpectedAt.TypeSize = ActivatedAt.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ExpectedAt.Encode());
            result.AddRange(ActivatedAt.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ExpectedAt = new U32();
            ExpectedAt.Decode(byteArray, ref p);
            ActivatedAt = new U32();
            ActivatedAt.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
