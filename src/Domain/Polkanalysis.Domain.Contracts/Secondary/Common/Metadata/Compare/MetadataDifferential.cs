using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Xml.Linq;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare
{
    public abstract class MetadataDiff<TDifferential, TStorageEntry, TCall, TEvent, TConstant, TError>
        where TDifferential : MetadataDifferentialModules<TStorageEntry, TCall, TEvent, TConstant, TError>
        where TStorageEntry : BaseType, IMetadataName, new()
        where TCall : BaseType, IMetadataName, new()
        where TEvent : BaseType, IMetadataName, new()
        where TConstant : BaseType, IMetadataName, new()
        where TError : BaseType, IMetadataName, new()
    {
        public IEnumerable<TDifferential> AllModulesDiff { get; set; }
            = Enumerable.Empty<TDifferential>();

        public IEnumerable<TDifferential> UnchangedModules
            => AllModulesDiff.Where(x =>
                !x.Storage.Any() &&
                !x.Calls.Any() &&
                !x.Events.Any() &&
                !x.Constants.Any() &&
                !x.Errors.Any()
            );

        public IEnumerable<TDifferential> ChangedModules
            => AllModulesDiff.Where(x =>
                !UnchangedModules.Any(y => y.ModuleName == x.ModuleName) &&
                !AddedModules.Any(y => y.ModuleName == x.ModuleName) &&
                !RemovedModules.Any(y => y.ModuleName == x.ModuleName));

        public IEnumerable<TDifferential> AddedModules
            => AllModulesDiff.Where(x => x.CompareStatus == CompareStatus.Added);

        public IEnumerable<TDifferential> RemovedModules
            => AllModulesDiff.Where(x => x.CompareStatus == CompareStatus.Removed);
    }

    public class MetadataDiffV9 : MetadataDiff<
        MetadataDifferentialModulesV9, StorageEntryMetadataV9, PalletCallMetadataV9, PalletEventMetadataV9, PalletConstantMetadataV9, PalletErrorMetadataV9>
    {
    }

    public class MetadataDifferentialModulesV9 : MetadataDifferentialModules<StorageEntryMetadataV9, PalletCallMetadataV9, PalletEventMetadataV9, PalletConstantMetadataV9, PalletErrorMetadataV9>
    {
    }

    public class MetadataDiffV10 : MetadataDiff<
        MetadataDifferentialModulesV10, StorageEntryMetadataV10, PalletCallMetadataV10, PalletEventMetadataV10, PalletConstantMetadataV10, PalletErrorMetadataV10>
    {
    }

    public class MetadataDifferentialModulesV10 : MetadataDifferentialModules<StorageEntryMetadataV10, PalletCallMetadataV10, PalletEventMetadataV10, PalletConstantMetadataV10, PalletErrorMetadataV10>
    {

    }

    public class MetadataDiffV11 : MetadataDiff<
        MetadataDifferentialModulesV11, StorageEntryMetadataV11, PalletCallMetadataV11, PalletEventMetadataV11, PalletConstantMetadataV11, PalletErrorMetadataV11>
    {
    }

    public class MetadataDifferentialModulesV11 : MetadataDifferentialModules<StorageEntryMetadataV11, PalletCallMetadataV11, PalletEventMetadataV11, PalletConstantMetadataV11, PalletErrorMetadataV11>
    {

    }

    public class MetadataDiffV12 : MetadataDiff<
        MetadataDifferentialModulesV12, StorageEntryMetadataV11, PalletCallMetadataV12, PalletEventMetadataV12, PalletConstantMetadataV12, PalletErrorMetadataV12>
    {
    }

    public class MetadataDifferentialModulesV12 : MetadataDifferentialModules<StorageEntryMetadataV11, PalletCallMetadataV12, PalletEventMetadataV12, PalletConstantMetadataV12, PalletErrorMetadataV12>
    {

    }

    public class MetadataDiffV13 : MetadataDiff<
        MetadataDifferentialModulesV13, StorageEntryMetadataV13, PalletCallMetadataV13, PalletEventMetadataV13, PalletConstantMetadataV13, PalletErrorMetadataV13>
    {
    }

    public class MetadataDifferentialModulesV13 : MetadataDifferentialModules<StorageEntryMetadataV13, PalletCallMetadataV13, PalletEventMetadataV13, PalletConstantMetadataV13, PalletErrorMetadataV13>
    {
    }

    public class MetadataDiffV14
    {
        public IEnumerable<MetadataDifferentialModulesV14> AllModulesDiff { get; set; }
            = Enumerable.Empty<MetadataDifferentialModulesV14>();

        public IEnumerable<MetadataDifferentialModulesV14> UnchangedModules
            => AllModulesDiff.Where(x =>
                !x.Storage.Any() &&
                !x.Calls.HasChanges() &&
                !x.Events.HasChanges() &&
                !x.Constants.Any() &&
                !x.Errors.HasChanges()
            );

        public IEnumerable<MetadataDifferentialModulesV14> ChangedModules
            => AllModulesDiff.Where(x =>
                !UnchangedModules.Any(y => y.ModuleName == x.ModuleName) &&
                !AddedModules.Any(y => y.ModuleName == x.ModuleName) &&
                !RemovedModules.Any(y => y.ModuleName == x.ModuleName));

        public IEnumerable<MetadataDifferentialModulesV14> AddedModules
            => AllModulesDiff.Where(x => x.CompareStatus == CompareStatus.Added);

        public IEnumerable<MetadataDifferentialModulesV14> RemovedModules
            => AllModulesDiff.Where(x => x.CompareStatus == CompareStatus.Removed);
    }

    public class MetadataDifferentialModulesV14
    {
        public string ModuleName { get; set; } = string.Empty;

        public CompareStatus CompareStatus { get; set; } = CompareStatus.AlreadyPresent;

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV14 storage))> Storage { get; set; }
            = Enumerable.Empty<(string, (CompareStatus, StorageEntryMetadataV14))>();
        public LookupDifferential Calls { get; set; } = new LookupDifferential();
        public LookupDifferential Events { get; set; } = new LookupDifferential();
        public IEnumerable<(CompareStatus, PalletConstantMetadataV14)> Constants { get; set; }
            = Enumerable.Empty<(CompareStatus, PalletConstantMetadataV14)>();
        public LookupDifferential Errors { get; set; } = new LookupDifferential();
    }

    public class MetadataDiffV15 : MetadataDiff<
        MetadataDifferentialModulesV15, StorageEntryMetadataV14, PalletCallMetadataV14, PalletEventMetadataV14, PalletConstantMetadataV14, PalletErrorMetadataV14>
    {
    }

    public class MetadataDifferentialModulesV15 : MetadataDifferentialModules<StorageEntryMetadataV14, PalletCallMetadataV14, PalletEventMetadataV14, PalletConstantMetadataV14, PalletErrorMetadataV14>
    {

    }
}
