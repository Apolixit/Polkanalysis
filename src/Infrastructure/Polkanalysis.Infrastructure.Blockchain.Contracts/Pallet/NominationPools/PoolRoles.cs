﻿using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    public class PoolRoles : BaseType
    {
        public SubstrateAccount Depositor { get; set; }
        public BaseOpt<SubstrateAccount> Root { get; set; }
        public BaseOpt<SubstrateAccount> Nominator { get; set; }
        public BaseOpt<SubstrateAccount>? StateToggler { get; set; }
        public BaseOpt<SubstrateAccount>? Bouncer { get; set; }

        public PoolRoles() { }

        public PoolRoles(SubstrateAccount depositor, BaseOpt<SubstrateAccount> root, BaseOpt<SubstrateAccount> nominator, BaseOpt<SubstrateAccount>? stateToggler, BaseOpt<SubstrateAccount>? bouncer)
        {
            Create(depositor, root, nominator, stateToggler, bouncer);
        }

        public void Create(SubstrateAccount depositor, BaseOpt<SubstrateAccount> root, BaseOpt<SubstrateAccount> nominator, BaseOpt<SubstrateAccount>? stateToggler, BaseOpt<SubstrateAccount>? bouncer)
        {
            Depositor = depositor;
            Root = root;
            Nominator = nominator;
            StateToggler = stateToggler;
            Bouncer = bouncer;

            Bytes = Encode();
            TypeSize = Depositor.TypeSize + Root.TypeSize + Nominator.TypeSize;
            if (StateToggler is not null)
                TypeSize += StateToggler.TypeSize;
            if (Bouncer is not null)
                TypeSize += Bouncer.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Root.Encode());
            result.AddRange(Nominator.Encode());

            if(StateToggler is not null)
                result.AddRange(StateToggler.Encode());

            if(Bouncer is not null)
                result.AddRange(Bouncer.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Depositor = new SubstrateAccount();
            Depositor.Decode(byteArray, ref p);
            Root = new BaseOpt<SubstrateAccount>();
            Root.Decode(byteArray, ref p);
            Nominator = new BaseOpt<SubstrateAccount>();
            Nominator.Decode(byteArray, ref p);
            StateToggler = new BaseOpt<SubstrateAccount>();
            StateToggler.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

        public override bool Equals(object? obj)
        {
            return obj is PoolRoles roles &&
                   TypeSize == roles.TypeSize &&
                   EqualityComparer<byte[]>.Default.Equals(Bytes, roles.Bytes) &&
                   EqualityComparer<SubstrateAccount>.Default.Equals(Depositor, roles.Depositor) &&
                   EqualityComparer<BaseOpt<SubstrateAccount>>.Default.Equals(Root, roles.Root) &&
                   EqualityComparer<BaseOpt<SubstrateAccount>>.Default.Equals(Nominator, roles.Nominator) &&
                   EqualityComparer<BaseOpt<SubstrateAccount>>.Default.Equals(StateToggler, roles.StateToggler);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeSize, Bytes, Depositor, Root, Nominator, StateToggler);
        }
    }
}
