using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types
{
    public class IncrementableU256 : BaseType
    {
        public U256 Value { get; set; } = default!;

        public IncrementableU256() { }
        
        public IncrementableU256(BigInteger num)
        {
            Value = new U256(num);
        }

        public IncrementableU256(double num)
        {
            Value = new U256(new BigInteger(num));
        }

        public override String TypeName()
        {
            return "IncrementableU256";
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
            Value = new Substrate.NetApi.Model.Types.Primitive.U256();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
