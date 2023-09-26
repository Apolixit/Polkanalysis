//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_proxy;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.pallet_proxy
{
    /// <summary>
    /// >> 4136 - Composite[pallet_proxy.ProxyDefinition]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ProxyDefinition : ProxyDefinitionBase
    {
        public override System.String TypeName()
        {
            return "ProxyDefinition";
        }

        public override System.Byte[] Encode()
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
            Delegate = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.sp_core.crypto.AccountId32();
            Delegate.Decode(byteArray, ref p);
            ProxyType = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9360.kusama_runtime.EnumProxyType();
            ProxyType.Decode(byteArray, ref p);
            Delay = new Substrate.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}