using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Multisig
{
    public class Timepoint : BaseType
    {
        public U32 Height { get; set; }
        public U32 Index { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Height.Encode());
            result.AddRange(Index.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Height = new U32();
            Height.Decode(byteArray, ref p);
            Index = new U32();
            Index.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
