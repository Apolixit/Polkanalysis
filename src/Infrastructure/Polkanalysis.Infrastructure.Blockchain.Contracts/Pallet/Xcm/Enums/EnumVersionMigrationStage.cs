using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.Enums
{
    [DomainMapping("pallet_xcm/pallet")]
    public enum VersionMigrationStage
    {

        MigrateSupportedVersion = 0,

        MigrateVersionNotifiers = 1,

        NotifyCurrentTargets = 2,

        MigrateAndNotifyOldTargets = 3,
    }

    /// <summary>
    /// >> 724 - Variant[pallet_xcm.pallet.VersionMigrationStage]
    /// </summary>
    public sealed class EnumVersionMigrationStage : BaseEnumExt<VersionMigrationStage, BaseVoid, BaseVoid, BaseOpt<BaseVec<U8>>, BaseVoid>
    {
    }
}
