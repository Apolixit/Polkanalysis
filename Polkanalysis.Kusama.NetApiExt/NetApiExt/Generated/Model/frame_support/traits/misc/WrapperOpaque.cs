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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.frame_support.traits.misc
{
    
    
    /// <summary>
    /// >> 568 - Composite[frame_support.traits.misc.WrapperOpaque]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class WrapperOpaque : BaseType
    {
        
        /// <summary>
        /// >> value0
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> _value0;
        
        /// <summary>
        /// >> T
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_im_online.BoundedOpaqueNetworkState _t;
        
        public Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32> Value0
        {
            get
            {
                return this._value0;
            }
            set
            {
                this._value0 = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_im_online.BoundedOpaqueNetworkState T
        {
            get
            {
                return this._t;
            }
            set
            {
                this._t = value;
            }
        }
        
        public override string TypeName()
        {
            return "WrapperOpaque";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value0.Encode());
            result.AddRange(T.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value0 = new Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U32>();
            Value0.Decode(byteArray, ref p);
            T = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_im_online.BoundedOpaqueNetworkState();
            T.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
