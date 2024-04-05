using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Paras
{
    public class DataCode : BaseType
    {
        public BaseVec<U8> Value { get; set; }

        public DataCode() { }

        public DataCode(string str)
        {
            Create(Utils.HexToByteArray(str));
        }

        public DataCode(BaseVec<U8> value)
        {
            Create(value);
        }

        public void Create(BaseVec<U8> value)
        {
            Value = value;
            Bytes = Encode();

            TypeSize = value.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new BaseVec<U8>();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
