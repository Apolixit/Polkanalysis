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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_babe;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.sp_consensus_babe
{
    /// <summary>
    /// >> 5705 - Composite[sp_consensus_babe.BabeEpochConfiguration]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BabeEpochConfiguration : BabeEpochConfigurationBase
    {
        public override System.String TypeName()
        {
            return "BabeEpochConfiguration";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(C.Encode());
            result.AddRange(AllowedSlots.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            C = new Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Primitive.U64>();
            C.Decode(byteArray, ref p);
            AllowedSlots = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.sp_consensus_babe.EnumAllowedSlots();
            AllowedSlots.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}