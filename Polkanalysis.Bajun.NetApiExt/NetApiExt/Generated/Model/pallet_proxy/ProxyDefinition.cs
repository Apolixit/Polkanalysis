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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_proxy
{
    
    
    /// <summary>
    /// >> 294 - Composite[pallet_proxy.ProxyDefinition]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ProxyDefinition : BaseType
    {
        
        /// <summary>
        /// >> delegate
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _delegate;
        
        /// <summary>
        /// >> proxy_type
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.bajun_runtime.proxy_type.EnumProxyType _proxyType;
        
        /// <summary>
        /// >> delay
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _delay;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Delegate
        {
            get
            {
                return this._delegate;
            }
            set
            {
                this._delegate = value;
            }
        }
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.bajun_runtime.proxy_type.EnumProxyType ProxyType
        {
            get
            {
                return this._proxyType;
            }
            set
            {
                this._proxyType = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 Delay
        {
            get
            {
                return this._delay;
            }
            set
            {
                this._delay = value;
            }
        }
        
        public override string TypeName()
        {
            return "ProxyDefinition";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Delegate.Encode());
            result.AddRange(ProxyType.Encode());
            result.AddRange(Delay.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Delegate = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Delegate.Decode(byteArray, ref p);
            ProxyType = new Polkanalysis.Bajun.NetApiExt.Generated.Model.bajun_runtime.proxy_type.EnumProxyType();
            ProxyType.Decode(byteArray, ref p);
            Delay = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
