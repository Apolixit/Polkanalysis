//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Types.Base;
using System.Collections.Generic;


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bounties
{
    
    
    public enum BountyStatus
    {
        
        Proposed = 0,
        
        Approved = 1,
        
        Funded = 2,
        
        CuratorProposed = 3,
        
        Active = 4,
        
        PendingPayout = 5,
    }
    
    /// <summary>
    /// >> 593 - Variant[pallet_bounties.BountyStatus]
    /// </summary>
    public sealed class EnumBountyStatus : BaseEnumExt<BountyStatus, BaseVoid, BaseVoid, BaseVoid, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
    }
}