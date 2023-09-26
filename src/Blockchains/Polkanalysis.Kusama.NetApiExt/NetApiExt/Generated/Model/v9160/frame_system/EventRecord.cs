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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.frame_system;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.frame_system
{
    /// <summary>
    /// >> 16099 - Composite[frame_system.EventRecord]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EventRecord : EventRecordBase
    {
        public override System.String TypeName()
        {
            return "EventRecord";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Phase.Encode());
            result.AddRange(Event1.Encode());
            result.AddRange(Topics.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Phase = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.frame_system.EnumPhase();
            Phase.Decode(byteArray, ref p);
            Event1 = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.kusama_runtime.EnumEvent();
            Event1.Decode(byteArray, ref p);
            Topics = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9160.primitive_types.H256>();
            Topics.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}