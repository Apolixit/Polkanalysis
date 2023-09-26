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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.scheduler;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_runtime_parachains.scheduler
{
    /// <summary>
    /// >> 5171 - Composite[polkadot_runtime_parachains.scheduler.QueuedParathread]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class QueuedParathread : QueuedParathreadBase
    {
        public override System.String TypeName()
        {
            return "QueuedParathread";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Claim1.Encode());
            result.AddRange(CoreOffset.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Claim1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.polkadot_primitives.v2.ParathreadEntry();
            Claim1.Decode(byteArray, ref p);
            CoreOffset = new Substrate.NetApi.Model.Types.Primitive.U32();
            CoreOffset.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}