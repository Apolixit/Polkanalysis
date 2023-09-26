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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_system;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.frame_system
{
    /// <summary>
    /// >> 4560 - Composite[frame_system.AccountInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class AccountInfo : AccountInfoBase
    {
        public override System.String TypeName()
        {
            return "AccountInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Nonce.Encode());
            result.AddRange(Consumers.Encode());
            result.AddRange(Providers.Encode());
            result.AddRange(Sufficients.Encode());
            result.AddRange(Data.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Nonce = new Substrate.NetApi.Model.Types.Primitive.U32();
            Nonce.Decode(byteArray, ref p);
            Consumers = new Substrate.NetApi.Model.Types.Primitive.U32();
            Consumers.Decode(byteArray, ref p);
            Providers = new Substrate.NetApi.Model.Types.Primitive.U32();
            Providers.Decode(byteArray, ref p);
            Sufficients = new Substrate.NetApi.Model.Types.Primitive.U32();
            Sufficients.Decode(byteArray, ref p);
            Data = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9200.pallet_balances.AccountData();
            Data.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}