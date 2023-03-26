//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Attributes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.vote
{
    
    
    /// <summary>
    /// >> 609 - Composite[pallet_conviction_voting.vote.Casting]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Casting : BaseType
    {
        
        /// <summary>
        /// >> votes
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT16 _votes;
        
        /// <summary>
        /// >> delegations
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.types.Delegations _delegations;
        
        /// <summary>
        /// >> prior
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.vote.PriorLock _prior;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT16 Votes
        {
            get
            {
                return this._votes;
            }
            set
            {
                this._votes = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.types.Delegations Delegations
        {
            get
            {
                return this._delegations;
            }
            set
            {
                this._delegations = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.vote.PriorLock Prior
        {
            get
            {
                return this._prior;
            }
            set
            {
                this._prior = value;
            }
        }
        
        public override string TypeName()
        {
            return "Casting";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Delegations.Encode());
            result.AddRange(Prior.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT16();
            Votes.Decode(byteArray, ref p);
            Delegations = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.types.Delegations();
            Delegations.Decode(byteArray, ref p);
            Prior = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.vote.PriorLock();
            Prior.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
