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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_preimage.pallet
{
    
    
    public enum Call
    {
        
        note_preimage = 0,
        
        unnote_preimage = 1,
        
        request_preimage = 2,
        
        unrequest_preimage = 3,
    }
    
    /// <summary>
    /// >> 234 - Variant[pallet_preimage.pallet.Call]
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class EnumCall : BaseEnumExt<Call, Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>, Substats.Kusama.NetApiExt.Generated.Model.primitive_types.H256, Substats.Kusama.NetApiExt.Generated.Model.primitive_types.H256, Substats.Kusama.NetApiExt.Generated.Model.primitive_types.H256>
    {
    }
}