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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.dispatch;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.frame_support.dispatch
{
    /// <summary>
    /// >> 11847 - Composite[frame_support.dispatch.PerDispatchClassT3]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PerDispatchClassT3 : PerDispatchClassT3Base
    {
        public override System.String TypeName()
        {
            return "PerDispatchClassT3";
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
            Normal = new Substrate.NetApi.Model.Types.Primitive.U32();
            Normal.Decode(byteArray, ref p);
            Operational = new Substrate.NetApi.Model.Types.Primitive.U32();
            Operational.Decode(byteArray, ref p);
            Mandatory = new Substrate.NetApi.Model.Types.Primitive.U32();
            Mandatory.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}