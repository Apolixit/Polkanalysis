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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.primitive_types
{
    
    
    /// <summary>
    /// >> 9 - Composite[primitive_types.H256]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class H256 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Types.Base.Arr32U8 _value;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Types.Base.Arr32U8 Value
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
            return "H256";
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
            Value = new Polkanalysis.Bajun.NetApiExt.Generated.Types.Base.Arr32U8();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
