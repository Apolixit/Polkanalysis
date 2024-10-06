using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System.Text;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display
{
    public abstract class Nameable : BaseType
    {
        public U8[] Value { get; set; }
        protected abstract int IntegerSize { get; set; }
        public override int TypeSize
        {
            get
            {
                return IntegerSize;
            }
        }

        public virtual string Display()
        {
            return Encoding.Default.GetString(Value.ToBytes());
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new U8[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new U8(); t.Decode(byteArray, ref p); array[i] = t; };
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }
    }
}
