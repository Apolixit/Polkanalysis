using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.AjunaExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools
{
    public class PoolMember : BaseType
    {
        public U32 PoolId { get; set; }
        public U128 Points { get; set; }
        public U128 LastRecordedRewardCounter { get; set; }

        /// <summary>
        /// https://docs.rs/pallet-nomination-pools/latest/pallet_nomination_pools/struct.PoolMember.html
        /// </summary>
        public BaseVec<BaseTuple<U32, U128>> UnbondingEras { get; set; }

        public PoolMember() { }

        public PoolMember(U32 poolId, U128 points, U128 lastRecordedRewardCounter, BaseVec<BaseTuple<U32, U128>> unbondingEras)
        {
            Create(poolId, points, lastRecordedRewardCounter, unbondingEras);
        }

        public void Create(U32 poolId, U128 points, U128 lastRecordedRewardCounter, BaseVec<BaseTuple<U32, U128>> unbondingEras)
        {
            PoolId = poolId;
            Points = points;
            LastRecordedRewardCounter = lastRecordedRewardCounter;
            UnbondingEras = unbondingEras;

            Bytes = Encode();
            TypeSize = PoolId.TypeSize + Points.TypeSize + LastRecordedRewardCounter.TypeSize + UnbondingEras.TypeSize;
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(PoolId.Encode());
            result.AddRange(Points.Encode());
            result.AddRange(LastRecordedRewardCounter.Encode());
            result.AddRange(UnbondingEras.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            PoolId = new U32();
            PoolId.Decode(byteArray, ref p);
            Points = new U128();
            Points.Decode(byteArray, ref p);
            LastRecordedRewardCounter = new U128();
            LastRecordedRewardCounter.Decode(byteArray, ref p);
            UnbondingEras = new BaseVec<BaseTuple<U32, U128>>();
            UnbondingEras.Decode(byteArray, ref p);
            TypeSize = p - start;
        }

    }
}
