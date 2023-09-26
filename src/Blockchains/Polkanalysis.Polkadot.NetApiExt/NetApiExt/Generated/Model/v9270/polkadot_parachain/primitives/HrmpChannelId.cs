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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_parachain.primitives;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.polkadot_parachain.primitives
{
    /// <summary>
    /// >> 8162 - Composite[polkadot_parachain.primitives.HrmpChannelId]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HrmpChannelId : HrmpChannelIdBase
    {
        public override System.String TypeName()
        {
            return "HrmpChannelId";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Sender.Encode());
            result.AddRange(Recipient.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Sender = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.polkadot_parachain.primitives.Id();
            Sender.Decode(byteArray, ref p);
            Recipient = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9270.polkadot_parachain.primitives.Id();
            Recipient.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}