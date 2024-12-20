﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking
{
    public class Nominations : BaseType
    {
        public BaseVec<SubstrateAccount> Targets { get; set; }
        public U32 SubmittedIn { get; set; }
        public Bool Suppressed { get; set; }

        public Nominations() { }

        public Nominations(BaseVec<SubstrateAccount> targets, U32 submittedIn, Bool suppressed)
        {
            Create(targets, submittedIn, suppressed);
        }

        public void Create(BaseVec<SubstrateAccount> targets, U32 submittedIn, Bool suppressed)
        {
            Targets = targets;
            SubmittedIn = submittedIn;
            Suppressed = suppressed;

            Bytes = Encode();
            TypeSize = Targets.TypeSize + SubmittedIn.TypeSize + Suppressed.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Targets.Encode());
            result.AddRange(SubmittedIn.Encode());
            result.AddRange(Suppressed.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Targets = new BaseVec<SubstrateAccount>();
            Targets.Decode(byteArray, ref p);
            SubmittedIn = new U32();
            SubmittedIn.Decode(byteArray, ref p);
            Suppressed = new Bool();
            Suppressed.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
