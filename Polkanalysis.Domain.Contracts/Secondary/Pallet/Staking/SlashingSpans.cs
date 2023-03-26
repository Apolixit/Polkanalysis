using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking
{
    public class SlashingSpans : BaseType
    {
        public U32 SpanIndex { get; set; }
        public U32 LastStart { get; set; }
        public U32 LastNonzeroSlash { get; set; }
        public BaseVec<U32> Prior { get; set; }

        public SlashingSpans() { }

        public SlashingSpans(U32 spanIndex, U32 lastStart, U32 lastNonzeroSlash, BaseVec<U32> prior)
        {
            Create(spanIndex, lastStart, lastNonzeroSlash, prior);
        }

        public void Create(U32 spanIndex, U32 lastStart, U32 lastNonzeroSlash, BaseVec<U32> prior)
        {
            SpanIndex = spanIndex;
            LastStart = lastStart;
            LastNonzeroSlash = lastNonzeroSlash;
            Prior = prior;

            Bytes = Encode();
            TypeSize = SpanIndex.TypeSize + LastStart.TypeSize + LastNonzeroSlash.TypeSize + Prior.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SpanIndex.Encode());
            result.AddRange(LastStart.Encode());
            result.AddRange(LastNonzeroSlash.Encode());
            result.AddRange(Prior.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SpanIndex = new U32();
            SpanIndex.Decode(byteArray, ref p);
            LastStart = new U32();
            LastStart.Decode(byteArray, ref p);
            LastNonzeroSlash = new U32();
            LastNonzeroSlash.Decode(byteArray, ref p);
            Prior = new BaseVec<U32>();
            Prior.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

    }
}
