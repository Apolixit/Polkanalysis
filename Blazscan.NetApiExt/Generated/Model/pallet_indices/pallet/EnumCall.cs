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


namespace Blazscan.NetApiExt.Generated.Model.pallet_indices.pallet
{
    
    
    public enum Call
    {
        
        claim = 0,
        
        transfer = 1,
        
        free = 2,
        
        force_transfer = 3,
        
        freeze = 4,
    }
    
    /// <summary>
    /// >> 198 - Variant[pallet_indices.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Ajuna.NetApi.Model.Types.Primitive.U32, BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Ajuna.NetApi.Model.Types.Primitive.U32>, Ajuna.NetApi.Model.Types.Primitive.U32, BaseTuple<Blazscan.NetApiExt.Generated.Model.sp_runtime.multiaddress.EnumMultiAddress, Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.Bool>, Ajuna.NetApi.Model.Types.Primitive.U32>
    {
    }
}
