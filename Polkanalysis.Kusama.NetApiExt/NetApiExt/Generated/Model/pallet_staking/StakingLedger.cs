//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Attributes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_staking
{
    
    
    /// <summary>
    /// >> 531 - Composite[pallet_staking.StakingLedger]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class StakingLedger : BaseType
    {
        
        /// <summary>
        /// >> stash
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _stash;
        
        /// <summary>
        /// >> total
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> _total;
        
        /// <summary>
        /// >> active
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> _active;
        
        /// <summary>
        /// >> unlocking
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6 _unlocking;
        
        /// <summary>
        /// >> claimed_rewards
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT7 _claimedRewards;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Stash
        {
            get
            {
                return this._stash;
            }
            set
            {
                this._stash = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128> Active
        {
            get
            {
                return this._active;
            }
            set
            {
                this._active = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6 Unlocking
        {
            get
            {
                return this._unlocking;
            }
            set
            {
                this._unlocking = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT7 ClaimedRewards
        {
            get
            {
                return this._claimedRewards;
            }
            set
            {
                this._claimedRewards = value;
            }
        }
        
        public override string TypeName()
        {
            return "StakingLedger";
        }
        
        public override byte[] Encode()
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
            Stash = new Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Stash.Decode(byteArray, ref p);
            Total = new Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128>();
            Total.Decode(byteArray, ref p);
            Active = new Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U128>();
            Active.Decode(byteArray, ref p);
            Unlocking = new Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6();
            Unlocking.Decode(byteArray, ref p);
            ClaimedRewards = new Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT7();
            ClaimedRewards.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
