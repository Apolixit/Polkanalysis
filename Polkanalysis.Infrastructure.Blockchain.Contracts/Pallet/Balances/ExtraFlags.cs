using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances
{
    public class ExtraFlags : BaseType
    {
        public U128 Value { get; set; } = new U128();

        public ExtraFlags() { }

        public ExtraFlags(U128 value) => Create(value);

        public void Create(U128 value)
        {
            Value = value;
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new U128();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
    }
}
