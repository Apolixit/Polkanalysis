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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_primitives.v2.collator_app
{
    
    
    /// <summary>
    /// >> 102 - Composite[polkadot_primitives.v2.collator_app.Public]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Public : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public _value;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        
        public override string TypeName()
        {
            return "Public";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.sr25519.Public();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
