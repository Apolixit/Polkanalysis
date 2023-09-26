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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_election_provider_multi_phase
{
    /// <summary>
    /// >> 10081 - Composite[pallet_election_provider_multi_phase.ReadySolution]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReadySolution : ReadySolutionBase
    {
        public override System.String TypeName()
        {
            return "ReadySolution";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Supports.Encode());
            result.AddRange(Score1.Encode());
            result.AddRange(Compute.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Supports = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_npos_elections.Support>>();
            Supports.Decode(byteArray, ref p);
            Score1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.sp_npos_elections.ElectionScore();
            Score1.Decode(byteArray, ref p);
            Compute = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9281.pallet_election_provider_multi_phase.EnumElectionCompute();
            Compute.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}