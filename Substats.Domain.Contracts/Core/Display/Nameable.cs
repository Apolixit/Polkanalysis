using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Core.Display
{
    /// <summary>
    /// This class represent something which can be displayed.
    /// Like pallet name, task name, account name
    /// </summary>
    public class Nameable : BaseType
    {
        public Nameable() { }
        public Nameable(BaseType elem)
        {
            IntegerSize = elem.TypeSize;
            Create(elem.Bytes);
        }

        public virtual string Display()
        {
            return System.Text.Encoding.Default.GetString(Value.ToBytes());
        }

        public U8[] Value { get; set; }
        protected int IntegerSize;

        public override int TypeSize
        {
            get
            {
                return IntegerSize;
            }
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
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Create(U8[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}
