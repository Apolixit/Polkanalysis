using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class PoolRoles : BaseType
    {
        public SubstrateAccount Depositor { get; set; }
        public BaseOpt<SubstrateAccount> Root { get; set; }
        public BaseOpt<SubstrateAccount> Nominator { get; set; }
        public BaseOpt<SubstrateAccount> StateToggler { get; set; }

        public PoolRoles() { }

        public PoolRoles(SubstrateAccount depositor, BaseOpt<SubstrateAccount> root, BaseOpt<SubstrateAccount> nominator, BaseOpt<SubstrateAccount> stateToggler)
        {
            Create(depositor, root, nominator, stateToggler);
        }

        public void Create(SubstrateAccount depositor, BaseOpt<SubstrateAccount> root, BaseOpt<SubstrateAccount> nominator, BaseOpt<SubstrateAccount> stateToggler)
        {
            Depositor = depositor;
            Root = root;
            Nominator = nominator;
            StateToggler = stateToggler;

            Bytes = Encode();
            TypeSize = Depositor.TypeSize + Root.TypeSize + Nominator.TypeSize + StateToggler.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Root.Encode());
            result.AddRange(Nominator.Encode());
            result.AddRange(StateToggler.Encode());
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
    }
}
