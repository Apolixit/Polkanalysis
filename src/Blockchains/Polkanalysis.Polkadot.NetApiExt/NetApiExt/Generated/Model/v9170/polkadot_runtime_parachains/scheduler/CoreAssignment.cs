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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.scheduler
{
    /// <summary>
    /// >> 3101 - Composite[polkadot_runtime_parachains.scheduler.CoreAssignment]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CoreAssignment : CoreAssignmentBase
    {
        public override System.String TypeName()
        {
            return "CoreAssignment";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Core.Encode());
            result.AddRange(ParaId.Encode());
            result.AddRange(Kind.Encode());
            result.AddRange(GroupIdx.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Core = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1.CoreIndex();
            Core.Decode(byteArray, ref p);
            ParaId = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_parachain.primitives.Id();
            ParaId.Decode(byteArray, ref p);
            Kind = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_runtime_parachains.scheduler.EnumAssignmentKind();
            Kind.Decode(byteArray, ref p);
            GroupIdx = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.polkadot_primitives.v1.GroupIndex();
            GroupIdx.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}