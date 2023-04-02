using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v2
{
    public class XcmT1 : BaseType
    {
        public BaseVec<EnumInstruction> Value { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new BaseVec<EnumInstruction>();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
