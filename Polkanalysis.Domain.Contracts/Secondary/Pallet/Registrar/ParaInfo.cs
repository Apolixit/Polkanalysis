using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using Polkanalysis.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Registrar
{
    public class ParaInfo : BaseType
    {
        public SubstrateAccount Manager { get; set; }
        public U128 Deposit { get; set; }
        public Bool Locked { get; set; }

        public ParaInfo() { }

        public ParaInfo(SubstrateAccount manager, U128 deposit, Bool locked)
        {
            Create(manager, deposit, locked);
        }

        public void Create(SubstrateAccount manager, U128 deposit, Bool locked)
        {
            Manager = manager;
            Deposit = deposit;
            Locked = locked;

            Bytes = Encode();
            TypeSize = Manager.TypeSize + Deposit.TypeSize + Locked.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Manager.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Locked.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Manager = new SubstrateAccount();
            Manager.Decode(byteArray, ref p);
            Deposit = new U128();
            Deposit.Decode(byteArray, ref p);
            Locked = new Bool();
            Locked.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
