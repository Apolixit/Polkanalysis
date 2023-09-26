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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system.limits;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.frame_system.limits
{
    /// <summary>
    /// >> 14373 - Composite[frame_system.limits.BlockWeights]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BlockWeights : BlockWeightsBase
    {
        public override System.String TypeName()
        {
            return "BlockWeights";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BaseBlock2.Encode());
            result.AddRange(MaxBlock2.Encode());
            result.AddRange(PerClass1.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BaseBlock2 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_weights.weight_v2.Weight();
            BaseBlock2.Decode(byteArray, ref p);
            MaxBlock2 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_weights.weight_v2.Weight();
            MaxBlock2.Decode(byteArray, ref p);
            PerClass1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.frame_support.dispatch.PerDispatchClassT2();
            PerClass1.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}