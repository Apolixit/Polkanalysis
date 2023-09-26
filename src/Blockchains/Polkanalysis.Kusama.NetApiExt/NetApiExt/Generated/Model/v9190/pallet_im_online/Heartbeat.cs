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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_im_online
{
    /// <summary>
    /// >> 14137 - Composite[pallet_im_online.Heartbeat]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Heartbeat : HeartbeatBase
    {
        public override System.String TypeName()
        {
            return "Heartbeat";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(BlockNumber.Encode());
            result.AddRange(NetworkState.Encode());
            result.AddRange(SessionIndex.Encode());
            result.AddRange(AuthorityIndex.Encode());
            result.AddRange(ValidatorsLen.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            BlockNumber = new Substrate.NetApi.Model.Types.Primitive.U32();
            BlockNumber.Decode(byteArray, ref p);
            NetworkState = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_core.offchain.OpaqueNetworkState();
            NetworkState.Decode(byteArray, ref p);
            SessionIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            SessionIndex.Decode(byteArray, ref p);
            AuthorityIndex = new Substrate.NetApi.Model.Types.Primitive.U32();
            AuthorityIndex.Decode(byteArray, ref p);
            ValidatorsLen = new Substrate.NetApi.Model.Types.Primitive.U32();
            ValidatorsLen.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}