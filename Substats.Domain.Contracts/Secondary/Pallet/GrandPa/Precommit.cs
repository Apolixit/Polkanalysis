using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.GrandPa
{
    public class Precommit : BaseType
    {
        public Hash TargetHash { get; set; }
        public U32 TargetNumber { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(TargetHash.Encode());
            result.AddRange(TargetNumber.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            TargetHash = new Hash();
            TargetHash.Decode(byteArray, ref p);
            TargetNumber = new U32();
            TargetNumber.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
