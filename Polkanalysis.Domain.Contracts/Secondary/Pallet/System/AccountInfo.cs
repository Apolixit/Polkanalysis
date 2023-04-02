using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore
{
    public class AccountInfo : BaseType
    {
        public U32 Nonce { get; set; }
        public U32 Consumers { get; set; }
        public U32 Providers { get; set; }
        public U32 Sufficients { get; set; }
        public AccountData Data { get; set; }

        public void Create(U32 nonce, U32 consumers, U32 providers, U32 sufficients, AccountData data)
        {
            Nonce = nonce;
            Consumers = consumers;
            Providers = providers;
            Sufficients = sufficients;
            Data = data;

            Bytes = Encode();
            TypeSize = Nonce.TypeSize + Consumers.TypeSize + Providers.TypeSize + Sufficients.TypeSize + Data.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Nonce.Encode());
            result.AddRange(Consumers.Encode());
            result.AddRange(Providers.Encode());
            result.AddRange(Sufficients.Encode());
            result.AddRange(Data.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Nonce = new U32();
            Nonce.Decode(byteArray, ref p);
            Consumers = new U32();
            Consumers.Decode(byteArray, ref p);
            Providers = new U32();
            Providers.Decode(byteArray, ref p);
            Sufficients = new U32();
            Sufficients.Decode(byteArray, ref p);
            Data = new AccountData();
            Data.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
