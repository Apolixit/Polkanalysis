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


namespace Substats.Kusama.NetApiExt.Generated.Model.sp_arithmetic.per_things
{
    
    
    /// <summary>
    /// >> 604 - Composite[sp_arithmetic.per_things.Permill]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Permill : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _value;
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 Value
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
            return "Permill";
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
            Value = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
