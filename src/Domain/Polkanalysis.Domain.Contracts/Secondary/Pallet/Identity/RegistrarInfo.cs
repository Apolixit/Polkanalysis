using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity
{
    public class RegistrarInfo : BaseType
    {
        public RegistrarInfo() { }

        public RegistrarInfo(SubstrateAccount account, U128 fee, U64 fields)
        {
            Create(account, fee, fields);
        }

        public void Create(SubstrateAccount account, U128 fee, U64 fields)
        {
            Account = account;
            Fee = fee;
            Fields = fields;

            Bytes = Encode();
            TypeSize = Account.TypeSize + Fee.TypeSize + Fields.TypeSize;
        }

        public SubstrateAccount Account { get; set; }
        public U128 Fee { get; set; }

        public U64 Fields { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Account.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(Fields.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Account = new SubstrateAccount();
            Account.Decode(byteArray, ref p);
            Fee = new U128();
            Fee.Decode(byteArray, ref p);
            Fields = new U64();
            Fields.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
