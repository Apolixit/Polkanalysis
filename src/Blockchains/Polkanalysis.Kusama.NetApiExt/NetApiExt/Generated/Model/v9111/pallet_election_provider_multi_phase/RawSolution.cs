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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.pallet_election_provider_multi_phase
{
    /// <summary>
    /// >> 20043 - Composite[pallet_election_provider_multi_phase.RawSolution]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RawSolution : RawSolutionBase
    {
        public override System.String TypeName()
        {
            return "RawSolution";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Solution.Encode());
            result.AddRange(Score1.Encode());
            result.AddRange(Round.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Solution = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.kusama_runtime.NposCompactSolution24();
            Solution.Decode(byteArray, ref p);
            Score1 = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr3U128();
            Score1.Decode(byteArray, ref p);
            Round = new Substrate.NetApi.Model.Types.Primitive.U32();
            Round.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}