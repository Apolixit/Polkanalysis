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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_support.dispatch;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.frame_support.dispatch
{
    /// <summary>
    /// >> 1324 - Composite[frame_support.dispatch.PostDispatchInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PostDispatchInfo : PostDispatchInfoBase
    {
        public override System.String TypeName()
        {
            return "PostDispatchInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ActualWeight.Encode());
            result.AddRange(PaysFee.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ActualWeight = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_weights.weight_v2.Weight>();
            ActualWeight.Decode(byteArray, ref p);
            PaysFee = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.frame_support.dispatch.EnumPays();
            PaysFee.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}