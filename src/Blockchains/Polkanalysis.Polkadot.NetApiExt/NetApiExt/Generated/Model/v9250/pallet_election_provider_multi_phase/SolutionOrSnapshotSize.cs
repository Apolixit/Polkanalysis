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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9250.pallet_election_provider_multi_phase
{
    /// <summary>
    /// >> 7010 - Composite[pallet_election_provider_multi_phase.SolutionOrSnapshotSize]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SolutionOrSnapshotSize : SolutionOrSnapshotSizeBase
    {
        public override System.String TypeName()
        {
            return "SolutionOrSnapshotSize";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Voters.Encode());
            result.AddRange(Targets.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Voters = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Voters.Decode(byteArray, ref p);
            Targets = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Targets.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}