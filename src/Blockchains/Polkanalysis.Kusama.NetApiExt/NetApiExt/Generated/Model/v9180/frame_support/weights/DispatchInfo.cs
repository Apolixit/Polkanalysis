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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.frame_support.weights
{
    /// <summary>
    /// >> 14620 - Composite[frame_support.weights.DispatchInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DispatchInfo : DispatchInfoBase
    {
        public override System.String TypeName()
        {
            return "DispatchInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Weight1.Encode());
            result.AddRange(Class.Encode());
            result.AddRange(PaysFee.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Weight1 = new Substrate.NetApi.Model.Types.Primitive.U64();
            Weight1.Decode(byteArray, ref p);
            Class = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.frame_support.weights.EnumDispatchClass();
            Class.Decode(byteArray, ref p);
            PaysFee = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9180.frame_support.weights.EnumPays();
            PaysFee.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}