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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_runtime.bounded.bounded_vec
{
    
    
    /// <summary>
    /// >> 293 - Composite[sp_runtime.bounded.bounded_vec.BoundedVecT11]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class BoundedVecT11 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_proxy.ProxyDefinition> _value;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_proxy.ProxyDefinition> Value
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
            return "BoundedVecT11";
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
            Value = new Ajuna.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_proxy.ProxyDefinition>();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
