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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_staking;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.pallet_staking
{
    /// <summary>
    /// >> 2275 - Composite[pallet_staking.EraRewardPoints]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class EraRewardPoints : EraRewardPointsBase
    {
        public override System.String TypeName()
        {
            return "EraRewardPoints";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Individual.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new Substrate.NetApi.Model.Types.Primitive.U32();
            Total.Decode(byteArray, ref p);
            Individual = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_core.crypto.AccountId32, Substrate.NetApi.Model.Types.Primitive.U32>>();
            Individual.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}