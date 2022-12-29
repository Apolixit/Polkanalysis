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


namespace Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.order
{
    
    
    public enum Order
    {
        
        Noop = 0,
        
        DepositAsset = 1,
        
        DepositReserveAsset = 2,
        
        ExchangeAsset = 3,
        
        InitiateReserveWithdraw = 4,
        
        InitiateTeleport = 5,
        
        QueryHolding = 6,
        
        BuyExecution = 7,
    }
    
    /// <summary>
    /// >> 444 - Variant[xcm.v1.order.Order]
    /// </summary>
    public sealed class EnumOrder : BaseEnumExt<Order, BaseVoid, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumMultiAssetFilter, Ajuna.NetApi.Model.Types.Primitive.U32, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumMultiAssetFilter, Ajuna.NetApi.Model.Types.Primitive.U32, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.order.EnumOrder>>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumMultiAssetFilter, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.MultiAssets>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumMultiAssetFilter, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.order.EnumOrder>>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumMultiAssetFilter, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.order.EnumOrder>>, BaseTuple<Ajuna.NetApi.Model.Types.Base.BaseCom<Ajuna.NetApi.Model.Types.Primitive.U64>, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.MultiLocation, Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumMultiAssetFilter>, BaseTuple<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.multiasset.MultiAsset, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.U64, Ajuna.NetApi.Model.Types.Primitive.Bool, Ajuna.NetApi.Model.Types.Base.BaseVec<Blazscan.Polkadot.NetApiExt.Generated.Model.xcm.v1.EnumXcm>>>
    {
    }
}
