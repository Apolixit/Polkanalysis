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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime_parachains.scheduler
{
    /// <summary>
    /// >> 6569 - Composite[polkadot_runtime_parachains.scheduler.ParathreadClaimQueue]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ParathreadClaimQueue : ParathreadClaimQueueBase
    {
        public override System.String TypeName()
        {
            return "ParathreadClaimQueue";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Queue.Encode());
            result.AddRange(NextCoreOffset.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Queue = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.polkadot_runtime_parachains.scheduler.QueuedParathread>();
            Queue.Decode(byteArray, ref p);
            NextCoreOffset = new Substrate.NetApi.Model.Types.Primitive.U32();
            NextCoreOffset.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}