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


namespace Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2
{
    
    
    /// <summary>
    /// >> 446 - Composite[xcm.v2.XcmT2]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class XcmT2 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2.EnumInstruction> _value;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2.EnumInstruction> Value
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
            return "XcmT2";
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
            Value = new Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.xcm.v2.EnumInstruction>();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
