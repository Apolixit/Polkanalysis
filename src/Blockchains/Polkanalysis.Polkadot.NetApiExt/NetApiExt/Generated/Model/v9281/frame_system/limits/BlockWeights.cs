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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.frame_system.limits
{
    /// <summary>
    /// >> 9649 - Composite[frame_system.limits.BlockWeights]
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
            result.AddRange(BaseBlock.Encode());
            result.AddRange(MaxBlock.Encode());
            result.AddRange(PerClass.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BaseBlock = new Substrate.NetApi.Model.Types.Primitive.U64();
            BaseBlock.Decode(byteArray, ref p);
            MaxBlock = new Substrate.NetApi.Model.Types.Primitive.U64();
            MaxBlock.Decode(byteArray, ref p);
            PerClass = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.frame_support.weights.PerDispatchClassT2();
            PerClass.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}