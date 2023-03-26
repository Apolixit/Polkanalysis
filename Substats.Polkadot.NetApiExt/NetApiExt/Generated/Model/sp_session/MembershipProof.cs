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


namespace Substats.Polkadot.NetApiExt.Generated.Model.sp_session
{
    
    
    /// <summary>
    /// >> 194 - Composite[sp_session.MembershipProof]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class MembershipProof : BaseType
    {
        
        /// <summary>
        /// >> session
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _session;
        
        /// <summary>
        /// >> trie_nodes
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> _trieNodes;
        
        /// <summary>
        /// >> validator_count
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _validatorCount;
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 Session
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
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>> TrieNodes
        {
            get
            {
                return this._trieNodes;
            }
            set
            {
                this._trieNodes = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 ValidatorCount
        {
            get
            {
                return this._validatorCount;
            }
            set
            {
                this._validatorCount = value;
            }
        }
        
        public override string TypeName()
        {
            return "MembershipProof";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Session.Encode());
            result.AddRange(TrieNodes.Encode());
            result.AddRange(ValidatorCount.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Session = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Session.Decode(byteArray, ref p);
            TrieNodes = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>();
            TrieNodes.Decode(byteArray, ref p);
            ValidatorCount = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ValidatorCount.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
