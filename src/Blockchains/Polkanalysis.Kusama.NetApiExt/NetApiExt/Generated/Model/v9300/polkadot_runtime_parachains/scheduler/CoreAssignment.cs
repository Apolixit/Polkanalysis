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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.scheduler;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_parachains.scheduler
{
    /// <summary>
    /// >> 7588 - Composite[polkadot_runtime_parachains.scheduler.CoreAssignment]
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
            result.AddRange(Core1.Encode());
            result.AddRange(ParaId.Encode());
            result.AddRange(Kind.Encode());
            result.AddRange(GroupIdx1.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Core1 = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.CoreIndex();
            Core1.Decode(byteArray, ref p);
            ParaId = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_parachain.primitives.Id();
            ParaId.Decode(byteArray, ref p);
            Kind = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_runtime_parachains.scheduler.EnumAssignmentKind();
            Kind.Decode(byteArray, ref p);
            GroupIdx1 = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9300.polkadot_primitives.v2.GroupIndex();
            GroupIdx1.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}