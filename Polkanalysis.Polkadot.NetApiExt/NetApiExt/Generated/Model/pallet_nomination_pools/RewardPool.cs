//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools
{
    
    
    /// <summary>
    /// >> 623 - Composite[pallet_nomination_pools.RewardPool]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class RewardPool : BaseType
    {
        
        /// <summary>
        /// >> last_recorded_reward_counter
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.fixed_point.FixedU128 _lastRecordedRewardCounter;
        
        /// <summary>
        /// >> last_recorded_total_payouts
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U128 _lastRecordedTotalPayouts;
        
        /// <summary>
        /// >> total_rewards_claimed
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U128 _totalRewardsClaimed;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.fixed_point.FixedU128 LastRecordedRewardCounter
        {
            get
            {
                return this._lastRecordedRewardCounter;
            }
            set
            {
                this._lastRecordedRewardCounter = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U128 LastRecordedTotalPayouts
        {
            get
            {
                return this._lastRecordedTotalPayouts;
            }
            set
            {
                this._lastRecordedTotalPayouts = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U128 TotalRewardsClaimed
        {
            get
            {
                return this._totalRewardsClaimed;
            }
            set
            {
                this._totalRewardsClaimed = value;
            }
        }
        
        public override string TypeName()
        {
            return "RewardPool";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(LastRecordedRewardCounter.Encode());
            result.AddRange(LastRecordedTotalPayouts.Encode());
            result.AddRange(TotalRewardsClaimed.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            LastRecordedRewardCounter = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.fixed_point.FixedU128();
            LastRecordedRewardCounter.Decode(byteArray, ref p);
            LastRecordedTotalPayouts = new Substrate.NetApi.Model.Types.Primitive.U128();
            LastRecordedTotalPayouts.Decode(byteArray, ref p);
            TotalRewardsClaimed = new Substrate.NetApi.Model.Types.Primitive.U128();
            TotalRewardsClaimed.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
