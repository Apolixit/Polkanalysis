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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_primitives.v2
{
    /// <summary>
    /// >> 5631 - Composite[polkadot_primitives.v2.CandidateCommitments]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateCommitments : CandidateCommitmentsBase
    {
        public override System.String TypeName()
        {
            return "CandidateCommitments";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(UpwardMessages.Encode());
            result.AddRange(HorizontalMessages.Encode());
            result.AddRange(NewValidationCode.Encode());
            result.AddRange(HeadData.Encode());
            result.AddRange(ProcessedDownwardMessages.Encode());
            result.AddRange(HrmpWatermark.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            UpwardMessages = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>();
            UpwardMessages.Decode(byteArray, ref p);
            HorizontalMessages = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_core_primitives.OutboundHrmpMessage>();
            HorizontalMessages.Decode(byteArray, ref p);
            NewValidationCode = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.ValidationCode>();
            NewValidationCode.Decode(byteArray, ref p);
            HeadData = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9220.polkadot_parachain.primitives.HeadData();
            HeadData.Decode(byteArray, ref p);
            ProcessedDownwardMessages = new Substrate.NetApi.Model.Types.Primitive.U32();
            ProcessedDownwardMessages.Decode(byteArray, ref p);
            HrmpWatermark = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpWatermark.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}