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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_referenda.types;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types
{
    /// <summary>
    /// >> 636 - Composite[pallet_referenda.types.ReferendumStatusT2]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReferendumStatusT2 : ReferendumStatusT2Base
    {
        public override System.String TypeName()
        {
            return "ReferendumStatusT2";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Track.Encode());
            result.AddRange(Origin.Encode());
            result.AddRange(Proposal.Encode());
            result.AddRange(Enactment.Encode());
            result.AddRange(Submitted.Encode());
            result.AddRange(SubmissionDeposit.Encode());
            result.AddRange(DecisionDeposit.Encode());
            result.AddRange(Deciding.Encode());
            result.AddRange(Tally.Encode());
            result.AddRange(InQueue.Encode());
            result.AddRange(Alarm.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Track = new Substrate.NetApi.Model.Types.Primitive.U16();
            Track.Decode(byteArray, ref p);
            Origin = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.kusama_runtime.EnumOriginCaller();
            Origin.Decode(byteArray, ref p);
            Proposal = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.frame_support.traits.preimages.EnumBounded();
            Proposal.Decode(byteArray, ref p);
            Enactment = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.frame_support.traits.schedule.EnumDispatchTime();
            Enactment.Decode(byteArray, ref p);
            Submitted = new Substrate.NetApi.Model.Types.Primitive.U32();
            Submitted.Decode(byteArray, ref p);
            SubmissionDeposit = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.Deposit();
            SubmissionDeposit.Decode(byteArray, ref p);
            DecisionDeposit = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.Deposit>();
            DecisionDeposit.Decode(byteArray, ref p);
            Deciding = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_referenda.types.DecidingStatus>();
            Deciding.Decode(byteArray, ref p);
            Tally = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_ranked_collective.Tally();
            Tally.Decode(byteArray, ref p);
            InQueue = new Substrate.NetApi.Model.Types.Primitive.Bool();
            InQueue.Decode(byteArray, ref p);
            Alarm = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>>();
            Alarm.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}