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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_support.weights;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.frame_support.weights
{
    /// <summary>
    /// >> 16090 - Composite[frame_support.weights.PerDispatchClassT1]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PerDispatchClassT1 : PerDispatchClassT1Base
    {
        public override System.String TypeName()
        {
            return "PerDispatchClassT1";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal1.Encode());
            result.AddRange(Operational1.Encode());
            result.AddRange(Mandatory1.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Normal1 = new Substrate.NetApi.Model.Types.Primitive.U64();
            Normal1.Decode(byteArray, ref p);
            Operational1 = new Substrate.NetApi.Model.Types.Primitive.U64();
            Operational1.Decode(byteArray, ref p);
            Mandatory1 = new Substrate.NetApi.Model.Types.Primitive.U64();
            Mandatory1.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}