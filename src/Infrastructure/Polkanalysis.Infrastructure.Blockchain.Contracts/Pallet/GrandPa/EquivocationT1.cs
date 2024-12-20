﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Signature;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa
{
    public class EquivocationT1 : BaseType
    {
        public U64 RoundNumber { get; set; }
        public PublicEd25519 Identity { get; set; }
        public BaseTuple<Prevote, SignatureEd25519> First { get; set; }
        public BaseTuple<Prevote, SignatureEd25519> Second { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(RoundNumber.Encode());
            result.AddRange(Identity.Encode());
            result.AddRange(First.Encode());
            result.AddRange(Second.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            RoundNumber = new U64();
            RoundNumber.Decode(byteArray, ref p);
            Identity = new PublicEd25519();
            Identity.Decode(byteArray, ref p);
            First = new BaseTuple<Prevote, SignatureEd25519>();
            First.Decode(byteArray, ref p);
            Second = new BaseTuple<Prevote, SignatureEd25519>();
            Second.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
