using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances
{
    public class AccountData : BaseType
    {
        public U128 Free { get; set; } = new U128();
        public U128 Reserved { get; set; } = new U128();
        public U128 MiscFrozen { get; set; } = new U128();
        public U128 FeeFrozen { get; set; } = new U128();

        public void Create(U128 free, U128 reserved, U128 miscFrozen, U128 feeFrozen)
        {
            this.Free = free;
            this.Reserved = reserved;
            this.MiscFrozen = miscFrozen;
            this.FeeFrozen = feeFrozen;

            Bytes = Encode();
            TypeSize = Free.TypeSize + Reserved.TypeSize + MiscFrozen.TypeSize + FeeFrozen.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Free.Encode());
            result.AddRange(Reserved.Encode());
            result.AddRange(MiscFrozen.Encode());
            result.AddRange(FeeFrozen.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Free = new U128();
            Free.Decode(byteArray, ref p);
            Reserved = new U128();
            Reserved.Decode(byteArray, ref p);
            MiscFrozen = new U128();
            MiscFrozen.Decode(byteArray, ref p);
            FeeFrozen = new U128();
            FeeFrozen.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
