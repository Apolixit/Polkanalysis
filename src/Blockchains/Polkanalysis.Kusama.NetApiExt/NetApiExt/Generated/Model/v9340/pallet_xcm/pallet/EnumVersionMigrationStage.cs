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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9340.pallet_xcm.pallet
{
    public enum VersionMigrationStage
    {
        MigrateSupportedVersion = 0,
        MigrateVersionNotifiers = 1,
        NotifyCurrentTargets = 2,
        MigrateAndNotifyOldTargets = 3
    }

    /// <summary>
    /// >> 6008 - Variant[pallet_xcm.pallet.VersionMigrationStage]
    /// </summary>
    public sealed class EnumVersionMigrationStage : BaseEnumExt<VersionMigrationStage, BaseVoid, BaseVoid, Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>, BaseVoid>
    {
    }
}