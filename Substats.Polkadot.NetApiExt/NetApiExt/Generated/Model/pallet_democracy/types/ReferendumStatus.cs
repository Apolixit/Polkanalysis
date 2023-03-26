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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types
{
    
    
    /// <summary>
    /// >> 534 - Composite[pallet_democracy.types.ReferendumStatus]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ReferendumStatus : BaseType
    {
        
        /// <summary>
        /// >> end
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _end;
        
        /// <summary>
        /// >> proposal
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded _proposal;
        
        /// <summary>
        /// >> threshold
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote_threshold.EnumVoteThreshold _threshold;
        
        /// <summary>
        /// >> delay
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _delay;
        
        /// <summary>
        /// >> tally
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.Tally _tally;
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 End
        {
            get
            {
                return this._end;
            }
            set
            {
                this._end = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded Proposal
        {
            get
            {
                return this._proposal;
            }
            set
            {
                this._proposal = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote_threshold.EnumVoteThreshold Threshold
        {
            get
            {
                return this._threshold;
            }
            set
            {
                this._threshold = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 Delay
        {
            get
            {
                return this._delay;
            }
            set
            {
                this._delay = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.Tally Tally
        {
            get
            {
                return this._tally;
            }
            set
            {
                this._tally = value;
            }
        }
        
        public override string TypeName()
        {
            return "ReferendumStatus";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(End.Encode());
            result.AddRange(Proposal.Encode());
            result.AddRange(Threshold.Encode());
            result.AddRange(Delay.Encode());
            result.AddRange(Tally.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            End = new Ajuna.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            Proposal = new Substats.Polkadot.NetApiExt.Generated.Model.frame_support.traits.preimages.EnumBounded();
            Proposal.Decode(byteArray, ref p);
            Threshold = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.vote_threshold.EnumVoteThreshold();
            Threshold.Decode(byteArray, ref p);
            Delay = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);
            Tally = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_democracy.types.Tally();
            Tally.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
