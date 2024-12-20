﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System
{
    public class AccountInfo : BaseType
    {
        public U32 Nonce { get; set; } = default!;
        public U32? RefCount { get; set; }
        public U32? Consumers { get; set; }
        public U32? Providers { get; set; }
        public U32? Sufficients { get; set; }
        public AccountData Data { get; set; } = default!;

        public AccountInfo() { }

        public AccountInfo(U32 nonce, U32 refCount, AccountData data)
        {
            Create(nonce, refCount, data);
        }

        public AccountInfo(U32 nonce, U32 consumers, U32 providers, AccountData data)
        {
            Create(nonce, consumers, providers, null, data);
        }

        public AccountInfo(U32 nonce, U32 consumers, U32 providers, U32 sufficients, AccountData data)
        {
            Create(nonce, consumers, providers, sufficients, data);
        }

        public void Create(U32 nonce, U32 refCount, AccountData data)
        {
            Nonce = nonce;
            RefCount = refCount;
            Data = data;

            Bytes = Encode();
            TypeSize = Nonce.TypeSize + RefCount.TypeSize + Data.TypeSize;
        }

        public void Create(U32 nonce, U32 consumers, U32 providers, U32? sufficients, AccountData data)
        {
            Nonce = nonce;
            Consumers = consumers;
            Providers = providers;
            Sufficients = sufficients;
            Data = data;

            Bytes = Encode();
            TypeSize = Nonce.TypeSize + 
                Consumers.TypeSize + 
                Providers.TypeSize + 
                (Sufficients != null ? Sufficients.TypeSize : 0) + 
                Data.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Nonce.Encode());
            if(Consumers is not null)
                result.AddRange(Consumers.Encode());

            if (Providers is not null)
                result.AddRange(Providers.Encode());

            if (Sufficients is not null)
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
