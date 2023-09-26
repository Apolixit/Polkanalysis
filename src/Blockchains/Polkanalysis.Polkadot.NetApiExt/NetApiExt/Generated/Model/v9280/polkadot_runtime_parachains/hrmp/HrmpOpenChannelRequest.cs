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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.hrmp;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9280.polkadot_runtime_parachains.hrmp
{
    /// <summary>
    /// >> 9434 - Composite[polkadot_runtime_parachains.hrmp.HrmpOpenChannelRequest]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HrmpOpenChannelRequest : HrmpOpenChannelRequestBase
    {
        public override System.String TypeName()
        {
            return "HrmpOpenChannelRequest";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Confirmed.Encode());
            result.AddRange(Age.Encode());
            result.AddRange(SenderDeposit.Encode());
            result.AddRange(MaxMessageSize.Encode());
            result.AddRange(MaxCapacity.Encode());
            result.AddRange(MaxTotalSize.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Confirmed = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Confirmed.Decode(byteArray, ref p);
            Age = new Substrate.NetApi.Model.Types.Primitive.U32();
            Age.Decode(byteArray, ref p);
            SenderDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            SenderDeposit.Decode(byteArray, ref p);
            MaxMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxMessageSize.Decode(byteArray, ref p);
            MaxCapacity = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxCapacity.Decode(byteArray, ref p);
            MaxTotalSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxTotalSize.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}