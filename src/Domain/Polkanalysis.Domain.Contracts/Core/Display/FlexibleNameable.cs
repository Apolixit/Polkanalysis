using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System.Text;
using Substrate.NetApi.Model.Types;
using Substrate.NET.Utils;

namespace Polkanalysis.Domain.Contracts.Core.Display
{
    /// <summary>
    /// This class represent something which can be displayed.
    /// Like pallet name, task name, account name
    /// </summary>
    public class FlexibleNameable : Nameable
    {
        public FlexibleNameable() { }

        public FlexibleNameable(string hex) => FromHexa(hex);

        public FlexibleNameable(U8[] data) => FromU8(data);

        public FlexibleNameable(BaseType elem) => FromBaseType(elem);
        public FlexibleNameable(IType elem) => FromIType(elem);

        #region Builder
        public FlexibleNameable FromText(string text)
        {
            Create(Encoding.Default.GetBytes(text).Select(x => new U8(x)).ToArray());
            return this;
        }
        public FlexibleNameable FromHexa(string hexa)
        {
            Create(Utils.HexToByteArray(hexa).Select(x => new U8(x)).ToArray());
            return this;
        }
        public FlexibleNameable FromBytes(byte[] bytes)
        {
            Create(bytes.Select(x => new U8(x)).ToArray());
            return this;
        }
        public FlexibleNameable FromU8(U8[] u8s)
        {
            Create(u8s);
            return this;
        }
        public FlexibleNameable FromBaseType(BaseType elem)
        {
            IntegerSize = elem.TypeSize;
            Create(elem.Bytes);
            return this;
        }

        public FlexibleNameable FromIType(IType elem)
        {
            IntegerSize = elem.TypeSize;
            Create(elem.GetBytes());
            return this;
        }
        #endregion

        protected override int IntegerSize { get; set; } = 0;

        public void Create(U8[] array)
        {
            Value = array;
            Bytes = Encode();
            IntegerSize = Bytes.Length;

            Create(Bytes);
        }
    }
}
