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


namespace Blazscan.NetApiExt.Generated.Model.polkadot_primitives.v2
{
    
    
    /// <summary>
    /// >> 406 - Composite[polkadot_primitives.v2.PvfCheckStatement]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class PvfCheckStatement : BaseType
    {
        
        /// <summary>
        /// >> accept
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.Bool _accept;
        
        /// <summary>
        /// >> subject
        /// </summary>
        private Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash _subject;
        
        /// <summary>
        /// >> session_index
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _sessionIndex;
        
        /// <summary>
        /// >> validator_index
        /// </summary>
        private Blazscan.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex _validatorIndex;
        
        public Ajuna.NetApi.Model.Types.Primitive.Bool Accept
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
        
        public Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash Subject
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
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 SessionIndex
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
        
        public Blazscan.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex ValidatorIndex
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
            Accept = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            Accept.Decode(byteArray, ref p);
            Subject = new Blazscan.NetApiExt.Generated.Model.polkadot_parachain.primitives.ValidationCodeHash();
            Subject.Decode(byteArray, ref p);
            SessionIndex = new Ajuna.NetApi.Model.Types.Primitive.U32();
            SessionIndex.Decode(byteArray, ref p);
            ValidatorIndex = new Blazscan.NetApiExt.Generated.Model.polkadot_primitives.v2.ValidatorIndex();
            ValidatorIndex.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
