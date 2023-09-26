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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_finality_grandpa;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_finality_grandpa
{
    /// <summary>
    /// >> 753 - Composite[sp_finality_grandpa.EquivocationProof]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EquivocationProof : EquivocationProofBase
    {
        public override System.String TypeName()
        {
            return "EquivocationProof";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SetId.Encode());
            result.AddRange(Equivocation.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SetId = new Substrate.NetApi.Model.Types.Primitive.U64();
            SetId.Decode(byteArray, ref p);
            Equivocation = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.sp_finality_grandpa.EnumEquivocation();
            Equivocation.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}