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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.sp_weights;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.sp_weights
{
    /// <summary>
    /// >> 6518 - Composite[sp_weights.RuntimeDbWeight]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RuntimeDbWeight : RuntimeDbWeightBase
    {
        public override System.String TypeName()
        {
            return "RuntimeDbWeight";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Read.Encode());
            result.AddRange(Write.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Read = new Substrate.NetApi.Model.Types.Primitive.U64();
            Read.Decode(byteArray, ref p);
            Write = new Substrate.NetApi.Model.Types.Primitive.U64();
            Write.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}