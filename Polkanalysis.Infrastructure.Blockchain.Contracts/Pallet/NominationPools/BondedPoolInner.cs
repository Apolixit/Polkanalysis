using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools
{
    public class BondedPoolInner : BaseType
    {
        public U128 Points { get; set; } = new U128();
        public EnumPoolState State { get; set; }
        public U32 MemberCounter { get; set; }
        public PoolRoles Roles { get; set; }
        public Commission? Commission { get; set; }

        public BondedPoolInner() { }

        public BondedPoolInner(U128 points, EnumPoolState state, U32 memberCounter, PoolRoles roles, Commission? commission)
        {
            Create(points, state, memberCounter, roles, commission);
        }

        public void Create(U128 points, EnumPoolState state, U32 memberCounter, PoolRoles roles, Commission? commission)
        {
            Points = points;
            State = state;
            MemberCounter = memberCounter;
            Roles = roles;
            Commission = commission;

            Bytes = Encode();
            TypeSize = Points.TypeSize + State.TypeSize + MemberCounter.TypeSize + Roles.TypeSize + Commission?.TypeSize ?? 0;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Points.Encode());
            result.AddRange(State.Encode());
            result.AddRange(MemberCounter.Encode());
            result.AddRange(Roles.Encode());
            
            if(Commission is not null)
                result.AddRange(Commission.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            throw new InvalidOperationException();
        }
    }
}
