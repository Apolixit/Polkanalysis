using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances
{
    public class IdAmount : BaseType
    {
        public IdAmount() { }

        public IdAmount(BaseTuple id, U128 amount)
        {
            Create(id, amount);
        }

        public void Create(BaseTuple id, U128 amount)
        {
            Id = id;
            Amount = amount;

            Bytes = Encode();

            TypeSize = Id.TypeSize + Amount.TypeSize;
        }

        public BaseTuple Id { get; set; }
        public EnumRuntimeFreezeReason IdFreezeReason { get; set; }
        public U128 Amount { get; set; }


        public override byte[] Encode()
        {
            var result = new List<byte>();
            
            if(Id is not null)
                result.AddRange(Id.Encode());

            if(IdFreezeReason is not null)
                result.AddRange(IdFreezeReason.Encode());
            
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new BaseTuple();
            Id.Decode(byteArray, ref p);
            Amount = new U128();
            Amount.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}
