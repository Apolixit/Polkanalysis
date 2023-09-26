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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_im_online;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_im_online
{
    /// <summary>
    /// >> 6591 - Composite[pallet_im_online.BoundedOpaqueNetworkState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class BoundedOpaqueNetworkState : BoundedOpaqueNetworkStateBase
    {
        public override System.String TypeName()
        {
            return "BoundedOpaqueNetworkState";
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
            PeerId = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            PeerId.Decode(byteArray, ref p);
            ExternalAddresses = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>();
            ExternalAddresses.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}