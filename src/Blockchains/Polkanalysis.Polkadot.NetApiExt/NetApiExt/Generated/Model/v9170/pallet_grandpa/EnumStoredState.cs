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

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9170.pallet_grandpa
{
    public enum StoredState
    {
        Live = 0,
        PendingPause = 1,
        Paused = 2,
        PendingResume = 3
    }

    /// <summary>
    /// >> 2978 - Variant[pallet_grandpa.StoredState]
    /// </summary>
    public sealed class EnumStoredState : BaseEnumExt<StoredState, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}