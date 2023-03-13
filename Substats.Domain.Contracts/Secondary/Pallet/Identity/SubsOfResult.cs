using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Newtonsoft.Json.Linq;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using System.Numerics;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class SubsOfResult : BaseType
    {
        public SubsOfResult() { }

        public SubsOfResult(U128 number, BaseVec<SubstrateAccount> accounts)
        {
            Create(number, accounts);
        }

        public void Create(U128 number, BaseVec<SubstrateAccount> accounts)
        {
            Number = number;
            Accounts = accounts;
        }

        public U128 Number { get; set; } = new U128();
        public BaseVec<SubstrateAccount> Accounts { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Number.Encode());
            result.AddRange(Accounts.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Number = new U128();
            Number.Decode(byteArray, ref p);
            Accounts = new BaseVec<SubstrateAccount>();
            Accounts.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
