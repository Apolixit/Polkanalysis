using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core
{
    public class Perbill : BaseType
    {
        public U32 Value { get; set; }

        public Perbill() { }

        public Perbill(U32 value)
        {
            Create(value);
        }

        public void Create(U32 value)
        {
            Value = value;

            Bytes = Encode();
            TypeSize = Value.TypeSize;
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
            Value = new U32();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
