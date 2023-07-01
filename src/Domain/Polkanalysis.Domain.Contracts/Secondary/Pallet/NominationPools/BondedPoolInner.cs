using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class BondedPoolInner : BaseType
    {
        public U128 Points { get; set; } = new U128();
        public EnumPoolState State { get; set; }
        public U32 MemberCounter { get; set; }
        public PoolRoles Roles { get; set; }

        public BondedPoolInner() { }

        public BondedPoolInner(U128 points, EnumPoolState state, U32 memberCounter, PoolRoles roles)
        {
            Create(points, state, memberCounter, roles);
        }

        public void Create(U128 points, EnumPoolState state, U32 memberCounter, PoolRoles roles)
        {
            Points = points;
            State = state;
            MemberCounter = memberCounter;
            Roles = roles;

            Bytes = Encode();
            TypeSize = Points.TypeSize + State.TypeSize + MemberCounter.TypeSize + Roles.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Points.Encode());
            result.AddRange(State.Encode());
            result.AddRange(MemberCounter.Encode());
            result.AddRange(Roles.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Points = new U128();
            Points.Decode(byteArray, ref p);
            State = new EnumPoolState();
            State.Decode(byteArray, ref p);
            MemberCounter = new U32();
            MemberCounter.Decode(byteArray, ref p);
            Roles = new PoolRoles();
            Roles.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
