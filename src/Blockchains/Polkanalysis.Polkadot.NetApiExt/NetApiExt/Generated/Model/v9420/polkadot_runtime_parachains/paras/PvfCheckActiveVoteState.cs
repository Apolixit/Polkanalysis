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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.paras;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.paras
{
    /// <summary>
    /// >> 14636 - Composite[polkadot_runtime_parachains.paras.PvfCheckActiveVoteState]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PvfCheckActiveVoteState : PvfCheckActiveVoteStateBase
    {
        public override System.String TypeName()
        {
            return "PvfCheckActiveVoteState";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(VotesAccept.Encode());
            result.AddRange(VotesReject.Encode());
            result.AddRange(Age.Encode());
            result.AddRange(CreatedAt.Encode());
            result.AddRange(Causes.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            VotesAccept = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.bitvec.order.Lsb0>();
            VotesAccept.Decode(byteArray, ref p);
            VotesReject = new Substrate.NetApi.Model.Types.Base.BaseBitSeq<Substrate.NetApi.Model.Types.Primitive.U8, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.bitvec.order.Lsb0>();
            VotesReject.Decode(byteArray, ref p);
            Age = new Substrate.NetApi.Model.Types.Primitive.U32();
            Age.Decode(byteArray, ref p);
            CreatedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            CreatedAt.Decode(byteArray, ref p);
            Causes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.polkadot_runtime_parachains.paras.EnumPvfCheckCause>();
            Causes.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}