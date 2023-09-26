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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_staking
{
    /// <summary>
    /// >> 17741 - Composite[pallet_staking.StakingLedger]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class StakingLedger : StakingLedgerBase
    {
        public override System.String TypeName()
        {
            return "StakingLedger";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Stash.Encode());
            result.AddRange(Total.Encode());
            result.AddRange(Active.Encode());
            result.AddRange(Unlocking.Encode());
            result.AddRange(ClaimedRewards.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Stash = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.sp_core.crypto.AccountId32();
            Stash.Decode(byteArray, ref p);
            Total = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            Total.Decode(byteArray, ref p);
            Active = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            Active.Decode(byteArray, ref p);
            Unlocking = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9150.pallet_staking.UnlockChunk>();
            Unlocking.Decode(byteArray, ref p);
            ClaimedRewards = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U32>();
            ClaimedRewards.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}