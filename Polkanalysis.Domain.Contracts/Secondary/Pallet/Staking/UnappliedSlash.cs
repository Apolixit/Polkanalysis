using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking
{
    public class UnappliedSlash : BaseType
    {
        public SubstrateAccount Validator { get; set; }
        public U128 Own { get; set; }
        public BaseVec<BaseTuple<SubstrateAccount, U128>> Others { get; set; }
        public BaseVec<SubstrateAccount> Reporters { get; set; }
        public U128 Payout { get; set; }

        public UnappliedSlash() { }

        public UnappliedSlash(SubstrateAccount validator, U128 own, BaseVec<BaseTuple<SubstrateAccount, U128>> others, BaseVec<SubstrateAccount> reporters, U128 payout)
        {
            Create(validator, own, others, reporters, payout);
        }

        public void Create(SubstrateAccount validator, U128 own, BaseVec<BaseTuple<SubstrateAccount, U128>> others, BaseVec<SubstrateAccount> reporters, U128 payout)
        {
            Validator = validator;
            Own = own;
            Others = others;
            Reporters = reporters;
            Payout = payout;

            Bytes = Encode();
            TypeSize = Validator.TypeSize + Own.TypeSize + Others.TypeSize + Reporters.TypeSize + Payout.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Validator.Encode());
            result.AddRange(Own.Encode());
            result.AddRange(Others.Encode());
            result.AddRange(Reporters.Encode());
            result.AddRange(Payout.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Validator = new SubstrateAccount();
            Validator.Decode(byteArray, ref p);
            Own = new U128();
            Own.Decode(byteArray, ref p);
            Others = new BaseVec<BaseTuple<SubstrateAccount, U128>>();
            Others.Decode(byteArray, ref p);
            Reporters = new BaseVec<SubstrateAccount>();
            Reporters.Decode(byteArray, ref p);
            Payout = new U128();
            Payout.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
