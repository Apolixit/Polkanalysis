using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Empty;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras
{
    public class PvfCheckActiveVoteState : BaseType
    {
        public BaseBitSeq<U8, Lsb0> VotesAccept { get; set; }
        public BaseBitSeq<U8, Lsb0> VotesReject { get; set; }
        public U32 Age { get; set; }
        public U32 CreatedAt { get; set; }
        public BaseVec<EnumPvfCheckCause> Causes { get; set; }

        public PvfCheckActiveVoteState() { }

        public PvfCheckActiveVoteState(BaseBitSeq<U8, Lsb0> votesAccept, BaseBitSeq<U8, Lsb0> votesReject, U32 age, U32 createdAt, BaseVec<EnumPvfCheckCause> causes)
        {
            Create(votesAccept, votesReject, age, createdAt, causes);
        }

        public void Create(BaseBitSeq<U8, Lsb0> votesAccept, BaseBitSeq<U8, Lsb0> votesReject, U32 age, U32 createdAt, BaseVec<EnumPvfCheckCause> causes)
        {
            VotesAccept = votesAccept;
            VotesReject = votesReject;
            Age = age;
            CreatedAt = createdAt;
            Causes = causes;

            Bytes = Encode();
            TypeSize = VotesAccept.TypeSize + VotesReject.TypeSize + Age.TypeSize + CreatedAt.TypeSize + Causes.TypeSize;
        }

        public override byte[] Encode()
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
            VotesAccept = new BaseBitSeq<U8, Lsb0>();
            VotesAccept.Decode(byteArray, ref p);
            VotesReject = new BaseBitSeq<U8, Lsb0>();
            VotesReject.Decode(byteArray, ref p);
            Age = new U32();
            Age.Decode(byteArray, ref p);
            CreatedAt = new U32();
            CreatedAt.Decode(byteArray, ref p);
            Causes = new BaseVec<EnumPvfCheckCause>();
            Causes.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
