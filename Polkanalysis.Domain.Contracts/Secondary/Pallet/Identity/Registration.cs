using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity
{
    public class Registration : BaseType
    {
        public Registration() { }

        public Registration(IdentityInfo info, U128 deposit, BaseVec<BaseTuple<U32, EnumJudgement>> judgements)
        {
            Create(info, deposit, judgements);
        }
        public void Create(IdentityInfo info, U128 deposit, BaseVec<BaseTuple<U32, EnumJudgement>> judgements)
        {
            Info = info;
            Deposit = deposit;
            Judgements = judgements;

            Bytes = Encode();
            TypeSize = Info.TypeSize + Deposit.TypeSize + Judgements.TypeSize;
        }

        public IdentityInfo Info { get; set; }
        public U128 Deposit { get; set; } = new U128();
        public BaseVec<BaseTuple<U32, EnumJudgement>> Judgements { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Judgements.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Info.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Judgements = new BaseVec<BaseTuple<U32, EnumJudgement>>();
            Judgements.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Info = new IdentityInfo();
            Info.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
