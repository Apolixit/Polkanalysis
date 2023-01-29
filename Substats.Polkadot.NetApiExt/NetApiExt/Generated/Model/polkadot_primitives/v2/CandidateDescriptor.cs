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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 98 - Composite[polkadot_primitives.v2.CandidateDescriptor]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateDescriptor : BaseType
    {
        
        /// <summary>
        /// >> para_id
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id _paraId;
        
        /// <summary>
        /// >> relay_parent
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _relayParent;
        
        /// <summary>
        /// >> collator
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app.Public _collator;
        
        /// <summary>
        /// >> persisted_validation_data_hash
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _persistedValidationDataHash;
        
        /// <summary>
        /// >> pov_hash
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _povHash;
        
        /// <summary>
        /// >> erasure_root
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _erasureRoot;
        
        /// <summary>
        /// >> signature
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app.Signature _signature;
        
        /// <summary>
        /// >> para_head
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _paraHead;
        
        /// <summary>
        /// >> validation_code_hash
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash _validationCodeHash;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id ParaId
        {
            get
            {
                return this._paraId;
            }
            set
            {
                this._paraId = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 RelayParent
        {
            get
            {
                return this._relayParent;
            }
            set
            {
                this._relayParent = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app.Public Collator
        {
            get
            {
                return this._collator;
            }
            set
            {
                this._collator = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 PersistedValidationDataHash
        {
            get
            {
                return this._persistedValidationDataHash;
            }
            set
            {
                this._persistedValidationDataHash = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 PovHash
        {
            get
            {
                return this._povHash;
            }
            set
            {
                this._povHash = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 ErasureRoot
        {
            get
            {
                return this._erasureRoot;
            }
            set
            {
                this._erasureRoot = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app.Signature Signature
        {
            get
            {
                return this._signature;
            }
            set
            {
                this._signature = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 ParaHead
        {
            get
            {
                return this._paraHead;
            }
            set
            {
                this._paraHead = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash ValidationCodeHash
        {
            get
            {
                return this._validationCodeHash;
            }
            set
            {
                this._validationCodeHash = value;
            }
        }
        
        public override string TypeName()
        {
            return "CandidateDescriptor";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParaId.Encode());
            result.AddRange(RelayParent.Encode());
            result.AddRange(Collator.Encode());
            result.AddRange(PersistedValidationDataHash.Encode());
            result.AddRange(PovHash.Encode());
            result.AddRange(ErasureRoot.Encode());
            result.AddRange(Signature.Encode());
            result.AddRange(ParaHead.Encode());
            result.AddRange(ValidationCodeHash.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParaId = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            ParaId.Decode(byteArray, ref p);
            RelayParent = new Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            RelayParent.Decode(byteArray, ref p);
            Collator = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app.Public();
            Collator.Decode(byteArray, ref p);
            PersistedValidationDataHash = new Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            PersistedValidationDataHash.Decode(byteArray, ref p);
            PovHash = new Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            PovHash.Decode(byteArray, ref p);
            ErasureRoot = new Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            ErasureRoot.Decode(byteArray, ref p);
            Signature = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app.Signature();
            Signature.Decode(byteArray, ref p);
            ParaHead = new Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            ParaHead.Decode(byteArray, ref p);
            ValidationCodeHash = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash();
            ValidationCodeHash.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}