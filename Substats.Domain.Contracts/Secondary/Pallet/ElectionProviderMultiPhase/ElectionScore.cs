﻿using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.ElectionProviderMultiPhase
{
    public class ElectionScore : BaseType
    {
        public U128 MinimalStake { get; set; }
        public U128 SumStake { get; set; }
        public U128 SumStakeSquared { get; set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MinimalStake.Encode());
            result.AddRange(SumStake.Encode());
            result.AddRange(SumStakeSquared.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MinimalStake = new Ajuna.NetApi.Model.Types.Primitive.U128();
            MinimalStake.Decode(byteArray, ref p);
            SumStake = new Ajuna.NetApi.Model.Types.Primitive.U128();
            SumStake.Decode(byteArray, ref p);
            SumStakeSquared = new Ajuna.NetApi.Model.Types.Primitive.U128();
            SumStakeSquared.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
