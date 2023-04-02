﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Core.Display;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances
{
    public class BalanceLock : BaseType
    {
        public Nameable Id { get; set; }
        public U128 Amount { get; set; } = new U128().With(BigInteger.Zero);
        public EnumReasons Reasons { get; set; }

        public void Create(Nameable id, U128 amount, EnumReasons reasons)
        {
            this.Id = id;
            this.Amount = amount;
            this.Reasons = reasons;

            Bytes = Encode();
            TypeSize = Id.TypeSize + Amount.TypeSize + Reasons.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(Reasons.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Nameable();
            Id.Decode(byteArray, ref p);
            Amount = new U128();
            Amount.Decode(byteArray, ref p);
            Reasons = new EnumReasons();
            Reasons.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}