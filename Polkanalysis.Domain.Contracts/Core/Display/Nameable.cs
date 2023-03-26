using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Org.BouncyCastle.Utilities.Encoders;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core.Random;
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
        public Nameable() : this(string.Empty)
        {
        }

        public Nameable(string hex)
        {
            //Create(Utils.HexToByteArray(hex).Select(x => new U8(x)).ToArray());
            FromHexa(hex);
        }

        public Nameable(U8[] data)
        {
            //Create(data);
            FromU8(data);
        }

        public Nameable(BaseType elem)
        {
            //IntegerSize = elem.TypeSize;
            //Create(elem.Bytes);
            FromBaseType(elem);
        }

        #region Builder
        public Nameable FromText(string text)
        {
            Create(Encoding.Default.GetBytes(text).Select(x => new U8(x)).ToArray());
            return this;
        }
        public Nameable FromHexa(string hexa)
        {
            Create(Utils.HexToByteArray(hexa).Select(x => new U8(x)).ToArray());
            return this;
        }
        public Nameable FromBytes(byte[] bytes)
        {
            Create(bytes.Select(x => new U8(x)).ToArray());
            return this;
        }
        public Nameable FromU8(U8[] u8s)
        {
            Create(u8s);
            return this;
        }
        public Nameable FromBaseType(BaseType elem)
        {
            IntegerSize = elem.TypeSize;
            Create(elem.Bytes);
            return this;
        }
        #endregion

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
            var array = new U8[byteArray.Length];
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
            IntegerSize = Bytes.Length;

            Create(Bytes);
        }

        //public virtual void Create(string str)
        //{

        //    Create(Encode());
        //    Create(Utils.HexToByteArray(str));
        //}
    }
}
