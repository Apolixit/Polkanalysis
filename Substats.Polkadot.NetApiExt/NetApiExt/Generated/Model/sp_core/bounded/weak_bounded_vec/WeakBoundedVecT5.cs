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


namespace Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec
{
    
    
    /// <summary>
    /// >> 519 - Composite[sp_core.bounded.weak_bounded_vec.WeakBoundedVecT5]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class WeakBoundedVecT5 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public> _value;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public> Value
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
            return "WeakBoundedVecT5";
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
            Value = new Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.pallet_im_online.sr25519.app_sr25519.Public>();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
