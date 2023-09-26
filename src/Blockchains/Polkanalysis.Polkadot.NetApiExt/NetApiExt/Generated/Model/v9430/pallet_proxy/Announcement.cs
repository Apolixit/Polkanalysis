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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_proxy;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_proxy
{
    /// <summary>
    /// >> 15383 - Composite[pallet_proxy.Announcement]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Announcement : AnnouncementBase
    {
        public override System.String TypeName()
        {
            return "Announcement";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Real.Encode());
            result.AddRange(CallHash.Encode());
            result.AddRange(Height.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Real = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32();
            Real.Decode(byteArray, ref p);
            CallHash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.primitive_types.H256();
            CallHash.Decode(byteArray, ref p);
            Height = new Substrate.NetApi.Model.Types.Primitive.U32();
            Height.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}