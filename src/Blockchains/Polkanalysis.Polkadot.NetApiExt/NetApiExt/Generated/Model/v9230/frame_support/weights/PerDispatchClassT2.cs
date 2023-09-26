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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.weights;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_support.weights
{
    /// <summary>
    /// >> 6113 - Composite[frame_support.weights.PerDispatchClassT2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PerDispatchClassT2 : PerDispatchClassT2Base
    {
        public override System.String TypeName()
        {
            return "PerDispatchClassT2";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Normal.Encode());
            result.AddRange(Operational.Encode());
            result.AddRange(Mandatory.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Normal = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.WeightsPerClass();
            Normal.Decode(byteArray, ref p);
            Operational = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.WeightsPerClass();
            Operational.Decode(byteArray, ref p);
            Mandatory = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.frame_system.limits.WeightsPerClass();
            Mandatory.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}