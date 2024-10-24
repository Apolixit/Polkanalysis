using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display
{
    public class DoubleEncoded : BaseType
    {
        public BaseVec<U8> Encoded { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Encoded.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Encoded = new BaseVec<U8>();
            Encoded.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
