using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking
{
    public class ActiveEraInfo : BaseType
    {
        public U32 Index { get; set; }
        public BaseOpt<U64> Start { get; set; }

        public ActiveEraInfo() { }

        public ActiveEraInfo(U32 index, BaseOpt<U64> start)
        {
            Create(index, start);
        }

        public void Create(U32 index, BaseOpt<U64> start)
        {
            Index = index;
            Start = start;

            Bytes = Encode();
            TypeSize = Index.TypeSize + Start.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Start.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new U32();
            Index.Decode(byteArray, ref p);
            Start = new BaseOpt<U64>();
            Start.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
