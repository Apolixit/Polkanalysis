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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking.slashing;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.pallet_staking.slashing
{
    /// <summary>
    /// >> 5741 - Composite[pallet_staking.slashing.SlashingSpans]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SlashingSpans : SlashingSpansBase
    {
        public override System.String TypeName()
        {
            return "SlashingSpans";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(SpanIndex.Encode());
            result.AddRange(LastStart.Encode());
            result.AddRange(LastNonzeroSlash.Encode());
            result.AddRange(Prior.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            SpanIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            SpanIndex.Decode(byteArray, ref p);
            LastStart = new Substrate.NetApi.Model.Types.Primitive.U32();
            LastStart.Decode(byteArray, ref p);
            LastNonzeroSlash = new Substrate.NetApi.Model.Types.Primitive.U32();
            LastNonzeroSlash.Decode(byteArray, ref p);
            Prior = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>();
            Prior.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}