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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras
{
    
    
    /// <summary>
    /// >> 665 - Composite[polkadot_runtime_parachains.paras.PvfCheckActiveVoteState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PvfCheckActiveVoteState : BaseType
    {
        
        /// <summary>
        /// >> votes_accept
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> _votesAccept;
        
        /// <summary>
        /// >> votes_reject
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> _votesReject;
        
        /// <summary>
        /// >> age
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _age;
        
        /// <summary>
        /// >> created_at
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _createdAt;
        
        /// <summary>
        /// >> causes
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.EnumPvfCheckCause> _causes;
        
        public Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> VotesAccept
        {
            get
            {
                return this._votesAccept;
            }
            set
            {
                this._votesAccept = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0> VotesReject
        {
            get
            {
                return this._votesReject;
            }
            set
            {
                this._votesReject = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 Age
        {
            get
            {
                return this._age;
            }
            set
            {
                this._age = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 CreatedAt
        {
            get
            {
                return this._createdAt;
            }
            set
            {
                this._createdAt = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.EnumPvfCheckCause> Causes
        {
            get
            {
                return this._causes;
            }
            set
            {
                this._causes = value;
            }
        }
        
        public override string TypeName()
        {
            return "PvfCheckActiveVoteState";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(VotesAccept.Encode());
            result.AddRange(VotesReject.Encode());
            result.AddRange(Age.Encode());
            result.AddRange(CreatedAt.Encode());
            result.AddRange(Causes.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            VotesAccept = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0>();
            VotesAccept.Decode(byteArray, ref p);
            VotesReject = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.bitvec.order.Lsb0>();
            VotesReject.Decode(byteArray, ref p);
            Age = new Substrate.NetApi.Model.Types.Primitive.U32();
            Age.Decode(byteArray, ref p);
            CreatedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            CreatedAt.Decode(byteArray, ref p);
            Causes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras.EnumPvfCheckCause>();
            Causes.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
