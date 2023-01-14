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


namespace Substats.Kusama.NetApiExt.Generated.Model.sp_core.crypto
{
    
    
    /// <summary>
    /// >> 560 - Composite[sp_core.crypto.KeyTypeId]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class KeyTypeId : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Substats.Kusama.NetApiExt.Generated.Types.Base.Arr4U8 _value;
        
        public Substats.Kusama.NetApiExt.Generated.Types.Base.Arr4U8 Value
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
            return "KeyTypeId";
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
            Value = new Substats.Kusama.NetApiExt.Generated.Types.Base.Arr4U8();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
