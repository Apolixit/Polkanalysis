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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_system.limits;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.frame_system.limits
{
    /// <summary>
    /// >> 12494 - Composite[frame_system.limits.WeightsPerClass]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class WeightsPerClass : WeightsPerClassBase
    {
        public override System.String TypeName()
        {
            return "WeightsPerClass";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BaseExtrinsic2.Encode());
            result.AddRange(MaxExtrinsic.Encode());
            result.AddRange(MaxTotal.Encode());
            result.AddRange(Reserved.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BaseExtrinsic2 = new Substrate.NetApi.Model.Types.Primitive.U64();
            BaseExtrinsic2.Decode(byteArray, ref p);
            MaxExtrinsic = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U64>();
            MaxExtrinsic.Decode(byteArray, ref p);
            MaxTotal = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U64>();
            MaxTotal.Decode(byteArray, ref p);
            Reserved = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U64>();
            Reserved.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}