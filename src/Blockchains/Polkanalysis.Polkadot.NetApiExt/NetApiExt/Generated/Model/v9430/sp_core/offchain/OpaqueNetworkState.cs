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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.offchain;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.offchain
{
    /// <summary>
    /// >> 14850 - Composite[sp_core.offchain.OpaqueNetworkState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class OpaqueNetworkState : OpaqueNetworkStateBase
    {
        public override System.String TypeName()
        {
            return "OpaqueNetworkState";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PeerId.Encode());
            result.AddRange(ExternalAddresses.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PeerId = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.OpaquePeerId();
            PeerId.Decode(byteArray, ref p);
            ExternalAddresses = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.offchain.OpaqueMultiaddr>();
            ExternalAddresses.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}