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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 408 - Composite[polkadot_primitives.v2.PvfCheckStatement]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PvfCheckStatement : BaseType
    {
        
        /// <summary>
        /// >> accept
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.Bool _accept;
        
        /// <summary>
        /// >> subject
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash _subject;
        
        /// <summary>
        /// >> session_index
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _sessionIndex;
        
        /// <summary>
        /// >> validator_index
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex _validatorIndex;
        
        public Substrate.NetApi.Model.Types.Primitive.Bool Accept
        {
            get
            {
                return this._accept;
            }
            set
            {
                this._accept = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash Subject
        {
            get
            {
                return this._subject;
            }
            set
            {
                this._subject = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 SessionIndex
        {
            get
            {
                return this._sessionIndex;
            }
            set
            {
                this._sessionIndex = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex ValidatorIndex
        {
            get
            {
                return this._validatorIndex;
            }
            set
            {
                this._validatorIndex = value;
            }
        }
        
        public override string TypeName()
        {
            return "PvfCheckStatement";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Accept.Encode());
            result.AddRange(Subject.Encode());
            result.AddRange(SessionIndex.Encode());
            result.AddRange(ValidatorIndex.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Accept = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Accept.Decode(byteArray, ref p);
            Subject = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash();
            Subject.Decode(byteArray, ref p);
            SessionIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            SessionIndex.Decode(byteArray, ref p);
            ValidatorIndex = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex();
            ValidatorIndex.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
