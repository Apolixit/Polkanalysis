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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.inclusion;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_runtime_parachains.inclusion
{
    /// <summary>
    /// >> 13012 - Composite[polkadot_runtime_parachains.inclusion.AvailabilityBitfieldRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AvailabilityBitfieldRecord : AvailabilityBitfieldRecordBase
    {
        public override System.String TypeName()
        {
            return "AvailabilityBitfieldRecord";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Bitfield1.Encode());
            result.AddRange(SubmittedAt.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Bitfield1 = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.polkadot_primitives.v2.AvailabilityBitfield();
            Bitfield1.Decode(byteArray, ref p);
            SubmittedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            SubmittedAt.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}