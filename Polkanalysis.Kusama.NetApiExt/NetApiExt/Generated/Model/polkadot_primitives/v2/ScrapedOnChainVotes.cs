//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 765 - Composite[polkadot_primitives.v2.ScrapedOnChainVotes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ScrapedOnChainVotes : BaseType
    {
        
        /// <summary>
        /// >> session
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _session;
        
        /// <summary>
        /// >> backing_validators_per_candidate
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateReceipt, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumValidityAttestation>>>> _backingValidatorsPerCandidate;
        
        /// <summary>
        /// >> disputes
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.DisputeStatementSet> _disputes;
        
        public Substrate.NetApi.Model.Types.Primitive.U32 Session
        {
            get
            {
                return this._session;
            }
            set
            {
                this._session = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateReceipt, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumValidityAttestation>>>> BackingValidatorsPerCandidate
        {
            get
            {
                return this._backingValidatorsPerCandidate;
            }
            set
            {
                this._backingValidatorsPerCandidate = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.DisputeStatementSet> Disputes
        {
            get
            {
                return this._disputes;
            }
            set
            {
                this._disputes = value;
            }
        }
        
        public override string TypeName()
        {
            return "ScrapedOnChainVotes";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Session.Encode());
            result.AddRange(BackingValidatorsPerCandidate.Encode());
            result.AddRange(Disputes.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Session = new Substrate.NetApi.Model.Types.Primitive.U32();
            Session.Decode(byteArray, ref p);
            BackingValidatorsPerCandidate = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateReceipt, Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex, Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.EnumValidityAttestation>>>>();
            BackingValidatorsPerCandidate.Decode(byteArray, ref p);
            Disputes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_primitives.v2.DisputeStatementSet>();
            Disputes.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
