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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.inclusion
{
    
    
    /// <summary>
    /// >> 645 - Composite[polkadot_runtime_parachains.inclusion.CandidatePendingAvailability]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class CandidatePendingAvailability : BaseType
    {
        
        /// <summary>
        /// >> core
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CoreIndex _core;
        
        /// <summary>
        /// >> hash
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_core_primitives.CandidateHash _hash;
        
        /// <summary>
        /// >> descriptor
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor _descriptor;
        
        /// <summary>
        /// >> availability_votes
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseBitSeq<Ajuna.NetApi.Model.Types.Primitive.U8, Substats.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> _availabilityVotes;
        
        /// <summary>
        /// >> backers
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseBitSeq<Ajuna.NetApi.Model.Types.Primitive.U8, Substats.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> _backers;
        
        /// <summary>
        /// >> relay_parent_number
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _relayParentNumber;
        
        /// <summary>
        /// >> backed_in_number
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _backedInNumber;
        
        /// <summary>
        /// >> backing_group
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.GroupIndex _backingGroup;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CoreIndex Core
        {
            get
            {
                return this._core;
            }
            set
            {
                this._core = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_core_primitives.CandidateHash Hash
        {
            get
            {
                return this._hash;
            }
            set
            {
                this._hash = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor Descriptor
        {
            get
            {
                return this._descriptor;
            }
            set
            {
                this._descriptor = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseBitSeq<Ajuna.NetApi.Model.Types.Primitive.U8, Substats.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> AvailabilityVotes
        {
            get
            {
                return this._availabilityVotes;
            }
            set
            {
                this._availabilityVotes = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseBitSeq<Ajuna.NetApi.Model.Types.Primitive.U8, Substats.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> Backers
        {
            get
            {
                return this._backers;
            }
            set
            {
                this._backers = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 RelayParentNumber
        {
            get
            {
                return this._relayParentNumber;
            }
            set
            {
                this._relayParentNumber = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 BackedInNumber
        {
            get
            {
                return this._backedInNumber;
            }
            set
            {
                this._backedInNumber = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.GroupIndex BackingGroup
        {
            get
            {
                return this._backingGroup;
            }
            set
            {
                this._backingGroup = value;
            }
        }
        
        public override string TypeName()
        {
            return "CandidatePendingAvailability";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Core.Encode());
            result.AddRange(Hash.Encode());
            result.AddRange(Descriptor.Encode());
            result.AddRange(AvailabilityVotes.Encode());
            result.AddRange(Backers.Encode());
            result.AddRange(RelayParentNumber.Encode());
            result.AddRange(BackedInNumber.Encode());
            result.AddRange(BackingGroup.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Core = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CoreIndex();
            Core.Decode(byteArray, ref p);
            Hash = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_core_primitives.CandidateHash();
            Hash.Decode(byteArray, ref p);
            Descriptor = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.CandidateDescriptor();
            Descriptor.Decode(byteArray, ref p);
            AvailabilityVotes = new Ajuna.NetApi.Model.Types.Base.BaseBitSeq<Ajuna.NetApi.Model.Types.Primitive.U8, Substats.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0>();
            AvailabilityVotes.Decode(byteArray, ref p);
            Backers = new Ajuna.NetApi.Model.Types.Base.BaseBitSeq<Ajuna.NetApi.Model.Types.Primitive.U8, Substats.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0>();
            Backers.Decode(byteArray, ref p);
            RelayParentNumber = new Ajuna.NetApi.Model.Types.Primitive.U32();
            RelayParentNumber.Decode(byteArray, ref p);
            BackedInNumber = new Ajuna.NetApi.Model.Types.Primitive.U32();
            BackedInNumber.Decode(byteArray, ref p);
            BackingGroup = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.GroupIndex();
            BackingGroup.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
