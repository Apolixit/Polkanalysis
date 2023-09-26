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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_runtime_parachains.paras
{
    /// <summary>
    /// >> 4494 - Composite[polkadot_runtime_parachains.paras.ReplacementTimes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReplacementTimes : ReplacementTimesBase
    {
        public override System.String TypeName()
        {
            return "ReplacementTimes";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ExpectedAt.Encode());
            result.AddRange(ActivatedAt.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ExpectedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            ExpectedAt.Decode(byteArray, ref p);
            ActivatedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            ActivatedAt.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}