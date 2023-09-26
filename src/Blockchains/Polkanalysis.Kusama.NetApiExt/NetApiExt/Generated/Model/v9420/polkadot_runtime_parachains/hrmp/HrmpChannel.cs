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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.hrmp;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.hrmp
{
    /// <summary>
    /// >> 1664 - Composite[polkadot_runtime_parachains.hrmp.HrmpChannel]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HrmpChannel : HrmpChannelBase
    {
        public override System.String TypeName()
        {
            return "HrmpChannel";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxCapacity.Encode());
            result.AddRange(MaxTotalSize.Encode());
            result.AddRange(MaxMessageSize.Encode());
            result.AddRange(MsgCount.Encode());
            result.AddRange(TotalSize.Encode());
            result.AddRange(MqcHead.Encode());
            result.AddRange(SenderDeposit.Encode());
            result.AddRange(RecipientDeposit.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxCapacity = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxCapacity.Decode(byteArray, ref p);
            MaxTotalSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxTotalSize.Decode(byteArray, ref p);
            MaxMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxMessageSize.Decode(byteArray, ref p);
            MsgCount = new Substrate.NetApi.Model.Types.Primitive.U32();
            MsgCount.Decode(byteArray, ref p);
            TotalSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            TotalSize.Decode(byteArray, ref p);
            MqcHead = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.primitive_types.H256>();
            MqcHead.Decode(byteArray, ref p);
            SenderDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            SenderDeposit.Decode(byteArray, ref p);
            RecipientDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            RecipientDeposit.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}