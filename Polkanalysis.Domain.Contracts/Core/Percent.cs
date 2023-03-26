using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Core
{
    public class Percent : BaseType
    {
        public U8 Value { get; set; }

        public Percent() { }

        public Percent(U8 value)
        {
            Create(value);
        }

        public void Create(U8 value)
        {
            Value = value;
            Bytes = value.Bytes;

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
            Value = new Ajuna.NetApi.Model.Types.Primitive.U8();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
