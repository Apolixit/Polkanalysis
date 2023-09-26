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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_election_provider_multi_phase;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.pallet_election_provider_multi_phase
{
    /// <summary>
    /// >> 5879 - Composite[pallet_election_provider_multi_phase.RoundSnapshot]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RoundSnapshot : RoundSnapshotBase
    {
        public override System.String TypeName()
        {
            return "RoundSnapshot";
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
            Voters = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U64, Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>>>();
            Voters.Decode(byteArray, ref p);
            Targets = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_core.crypto.AccountId32>();
            Targets.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}