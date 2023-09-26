//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_nomination_pools;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.pallet_nomination_pools
{
    /// <summary>
    /// >> 5903 - Composite[pallet_nomination_pools.PoolMember]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PoolMember : PoolMemberBase
    {
        public override System.String TypeName()
        {
            return "PoolMember";
        }

        public override System.Byte[] Encode()
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
            PoolId = new Substrate.NetApi.Model.Types.Primitive.U32();
            PoolId.Decode(byteArray, ref p);
            Points = new Substrate.NetApi.Model.Types.Primitive.U128();
            Points.Decode(byteArray, ref p);
            LastRecordedRewardCounter = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.sp_arithmetic.fixed_point.FixedU128();
            LastRecordedRewardCounter.Decode(byteArray, ref p);
            UnbondingEras = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U128>>();
            UnbondingEras.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}