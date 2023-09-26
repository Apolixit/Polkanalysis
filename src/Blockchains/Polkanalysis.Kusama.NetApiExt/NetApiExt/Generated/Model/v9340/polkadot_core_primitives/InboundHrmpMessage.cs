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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_core_primitives;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.polkadot_core_primitives
{
    /// <summary>
    /// >> 5975 - Composite[polkadot_core_primitives.InboundHrmpMessage]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class InboundHrmpMessage : InboundHrmpMessageBase
    {
        public override System.String TypeName()
        {
            return "InboundHrmpMessage";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SentAt.Encode());
            result.AddRange(Data.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SentAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            SentAt.Decode(byteArray, ref p);
            Data = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Data.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}