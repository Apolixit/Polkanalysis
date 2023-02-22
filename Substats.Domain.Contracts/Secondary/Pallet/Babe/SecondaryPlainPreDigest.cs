using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public class SecondaryPlainPreDigest : BaseType
    {
        public U32 AuthorityIndex { get; set; }
        public U64 Slot { get; set; }
        public int TypeSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(AuthorityIndex.Encode());
            result.AddRange(Slot.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            AuthorityIndex = new Ajuna.NetApi.Model.Types.Primitive.U32();
            AuthorityIndex.Decode(byteArray, ref p);
            Slot = new U64();
            Slot.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
