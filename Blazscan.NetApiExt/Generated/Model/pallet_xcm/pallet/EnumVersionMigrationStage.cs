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


namespace Blazscan.NetApiExt.Generated.Model.pallet_xcm.pallet
{
    
    
    public enum VersionMigrationStage
    {
        
        MigrateSupportedVersion = 0,
        
        MigrateVersionNotifiers = 1,
        
        NotifyCurrentTargets = 2,
        
        MigrateAndNotifyOldTargets = 3,
    }
    
    /// <summary>
    /// >> 721 - Variant[pallet_xcm.pallet.VersionMigrationStage]
    /// </summary>
    public sealed class EnumVersionMigrationStage : BaseEnumExt<VersionMigrationStage, BaseVoid, BaseVoid, Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>>, BaseVoid>
    {
    }
}
