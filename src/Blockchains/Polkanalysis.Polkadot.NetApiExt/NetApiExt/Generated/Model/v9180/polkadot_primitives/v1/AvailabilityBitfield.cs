//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v1;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_primitives.v1
{
    /// <summary>
    /// >> 3539 - Composite[polkadot_primitives.v1.AvailabilityBitfield]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AvailabilityBitfield : AvailabilityBitfieldBase
    {
        public override System.String TypeName()
        {
            return "AvailabilityBitfield";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.bitvec.order.Lsb0>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}