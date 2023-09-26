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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4
{
    /// <summary>
    /// >> 15979 - Composite[polkadot_primitives.v4.ScrapedOnChainVotesBase]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public abstract class ScrapedOnChainVotesBase : BaseType
    {
        /// <summary>
        /// >> session
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 Session { get; set; }
        /// <summary>
        /// >> backing_validators_per_candidate
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable BackingValidatorsPerCandidate { get; set; }
        /// <summary>
        /// >> disputes
        /// </summary>
        public Substrate.NetApi.Model.Types.Base.Abstraction.IBaseEnumerable Disputes { get; set; }

        public override System.String TypeName()
        {
            return "ScrapedOnChainVotesBase";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Session.Encode());
            result.AddRange(BackingValidatorsPerCandidate.Encode());
            result.AddRange(Disputes.Encode());
            return result.ToArray();
        }

        public static Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ScrapedOnChainVotesBase Create(byte[] data, uint version)
        {
            Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v4.ScrapedOnChainVotesBase instance = null;
            if (version == 9420U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.ScrapedOnChainVotes();
                instance.Create(data);
            }

            if (version == 9430U)
            {
                instance = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.polkadot_primitives.v4.ScrapedOnChainVotes();
                instance.Create(data);
            }

            return instance;
        }
    }
}