using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base.Portable;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare.TypeDef;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V14;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Polkanalysis.Domain.Contracts.Service;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Service
{
    public class MetadataService : IMetadataService
    {
        public Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, int specVersion1, int specVersion2)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, string hexMetadata1, string hexMetadata2)
        {
            Guard.Against.NullOrEmpty(palletName);
            Guard.Against.NullOrEmpty(hexMetadata1);
            Guard.Against.NullOrEmpty(hexMetadata2);

            var version = EnsureMetadataVersion(hexMetadata1, hexMetadata2);

            if(version == MetadataVersion.V14)
            {
                var v14Compare = await MetadataCompareV14Async(new MetadataV14(hexMetadata1), new MetadataV14(hexMetadata2));

                return v14Compare.ChangedModules.Any(x => x.ModuleName == palletName);
            }

            return false;
        }



        #region Metadata compare
        public MetadataVersion EnsureMetadataVersion(string hexMetadata1, string hexMetadata2)
        {
            Guard.Against.NullOrEmpty(hexMetadata1);
            Guard.Against.NullOrEmpty(hexMetadata2);

            // To be compared, Metadata should have same Major version
            CheckRuntimeMetadata checkVersion1 = new(hexMetadata1);
            CheckRuntimeMetadata checkVersion2 = new(hexMetadata2);

            if (checkVersion1.MetaDataInfo.Version.Value != checkVersion2.MetaDataInfo.Version.Value)
                throw new InvalidOperationException($"Cannot compare metadata v{checkVersion1.MetaDataInfo.Version.Value} and v{checkVersion2.MetaDataInfo.Version.Value}. Major version have to be the same.");

            return checkVersion1.MetaDataInfo.Version.Value switch
            {
                9 => MetadataVersion.V9,
                10 => MetadataVersion.V10,
                11 => MetadataVersion.V11,
                12 => MetadataVersion.V12,
                13 => MetadataVersion.V13,
                14 => MetadataVersion.V14,
                _ => throw new InvalidOperationException($"Metadata version {checkVersion1.MetaDataInfo.Version.Value} is not supported")
            };
        }

        /// <summary>
        /// Compare element by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public IEnumerable<(CompareStatus, T)> NameDiff<T>(
            IEnumerable<T>? source,
            IEnumerable<T>? destination)
            where T : IMetadataName
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, T)> TypeDiff<T>(
            IEnumerable<T>? source,
            IEnumerable<T>? destination)
            where T : IMetadataType
            => MetadataModuleCompare(source, destination, (x, y) => x.ItemType.Value == y.ItemType.Value);

        public IEnumerable<(CompareStatus, TType)> TypeDiff(
            IEnumerable<TType>? source,
            IEnumerable<TType>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Value == y.Value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modulesStart"></param>
        /// <param name="uncommonModules"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IEnumerable<T> FilterModuleByStatus<T>(IEnumerable<T> modulesStart, IEnumerable<(CompareStatus, T)> uncommonModules, CompareStatus status)
            where T : IMetadataName, IType, new()
        {
            if (uncommonModules.Any())
            {
                var modulesToRemove = uncommonModules.Where(x => x.Item1 == status);
                modulesStart = modulesStart.Where(x => !modulesToRemove.Any(y => y.Item2.Name.Value == x.Name.Value));
            }

            return modulesStart.OrderBy(x => x.Name.Value);
        }

        #endregion

        #region Utils
        /// <summary>
        /// Compare module metadata from version 9 to 13
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private IEnumerable<(CompareStatus, T)> MetadataModuleCompare<T>(
            IEnumerable<T>? source,
            IEnumerable<T>? destination,
            Func<T, T, bool> predicate)
        {
            var res = new List<(CompareStatus, T)>();

            if (source == null && destination == null) return res;
            if (source == null && destination != null) return destination.Select(x => (CompareStatus.Added, x));
            if (source != null && destination == null) return source.Select(x => (CompareStatus.Removed, x));

            // First we check what call have been added
            var added = destination!.Where(x => !source!.Any(y => predicate(x, y)));
            res.AddRange(added.Select(x => (CompareStatus.Added, x)));

            var removed = source!.Where(x => !destination!.Any(y => predicate(x, y)));
            res.AddRange(removed.Select(x => (CompareStatus.Removed, x)));

            return res;
        }

        private bool AreStringsEquals(BaseVec<Str> source, BaseVec<Str> target)
            => AreStringsEquals(source.Value, target.Value);

        private bool AreStringsEquals(IEnumerable<Str> source, IEnumerable<Str> target)
        {
            return !source.Select(x => x.Value).Except(target.Select(x => x.Value)).Any();
        }

        private IEnumerable<T> Sanitize<T>(IEnumerable<BaseOpt<BaseVec<T>>> elems)
            where T : IType, new()
        {
            if (elems == null) return Enumerable.Empty<T>();

            var res = elems
                .Where(x => x.OptionFlag)
                .SelectMany(x => x.Value.Value);

            return res;
        }

        private IEnumerable<T> Sanitize<T>(IEnumerable<BaseVec<T>> elems)
            where T : IType, new()
        {
            if (elems == null) return Enumerable.Empty<T>();

            var res = elems
                .SelectMany(x => x.Value);

            return res;
        }

        private IEnumerable<T> Sanitize<T>(BaseOpt<BaseVec<T>> elems)
            where T : IType, new()
        {
            if (elems == null || !elems.OptionFlag) return Enumerable.Empty<T>();

            return elems.Value.Value;
        }

        private IEnumerable<T> Sanitize<T>(BaseVec<T> elems)
            where T : IType, new()
        {
            if (elems == null) return Enumerable.Empty<T>();

            return elems.Value;
        }

        #endregion

        #region Compare V9
        public Task<MetadataDiffV9> MetadataCompareV9Async(MetadataV9 m1, MetadataV9 m2)
        {
            var resModulesDiff = new List<MetadataDifferentialModulesV9>();

            // Check added / removed pallet
            var nonCommonModules = NameDiff(Sanitize(m1.RuntimeMetadataData.Modules), Sanitize(m2.RuntimeMetadataData.Modules));

            resModulesDiff.AddRange(nonCommonModules.Select(x => x.Item2.ToDifferentialModules(x.Item1)));

            // We insert added modules
            var m1CommonModules = FilterModuleByStatus(m1.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Removed);
            var m2CommonModules = FilterModuleByStatus(m2.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Added);

            foreach (var elem in m1CommonModules.Zip(m2CommonModules))
            {
                resModulesDiff.Add(new MetadataDifferentialModulesV9()
                {
                    ModuleName = elem.First.Name.Value,
                    Storage = CompareModuleStorageV9(elem.First.Storage.Value, elem.Second.Storage.Value),
                    Calls = CompareModuleCallsV9(Sanitize(elem.First.Calls), Sanitize(elem.Second.Calls)),
                    Events = CompareModuleEventsV9(Sanitize(elem.First.Events), Sanitize(elem.Second.Events)),
                    Constants = CompareModuleConstantsV9(Sanitize(elem.First.Constants), Sanitize(elem.Second.Constants)),
                    Errors = CompareModuleErrorsV9(Sanitize(elem.First.Errors), Sanitize(elem.Second.Errors))
                });
            }

            return Task.FromResult(new MetadataDiffV9()
            {
                AllModulesDiff = resModulesDiff
            });
        }

        public IEnumerable<(CompareStatus, PalletCallMetadataV9)> CompareModuleCallsV9(
            IEnumerable<PalletCallMetadataV9>? source,
            IEnumerable<PalletCallMetadataV9>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletEventMetadataV9)> CompareModuleEventsV9(BaseVec<ModuleMetadataV9> source, BaseVec<ModuleMetadataV9> destination)
            => CompareModuleEventsV9(
                Sanitize(source.Value.Select(x => x.Events)),
                Sanitize(destination.Value.Select(x => x.Events)));

        public IEnumerable<(CompareStatus, PalletEventMetadataV9)> CompareModuleEventsV9(
            IEnumerable<PalletEventMetadataV9>? source,
            IEnumerable<PalletEventMetadataV9>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletConstantMetadataV9)> CompareModuleConstantsV9(BaseVec<ModuleMetadataV9> source, BaseVec<ModuleMetadataV9> destination)
            => CompareModuleConstantsV9(
                Sanitize(source.Value.Select(x => x.Constants)),
                Sanitize(destination.Value.Select(x => x.Constants)));

        public IEnumerable<(CompareStatus, PalletConstantMetadataV9)> CompareModuleConstantsV9(
            IEnumerable<PalletConstantMetadataV9>? source,
            IEnumerable<PalletConstantMetadataV9>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletErrorMetadataV9)> CompareModuleErrorsV9(BaseVec<ModuleMetadataV9> source, BaseVec<ModuleMetadataV9> destination)
            => CompareModuleErrorsV9(
                Sanitize(source.Value.Select(x => x.Errors)),
                Sanitize(destination.Value.Select(x => x.Errors)));

        public IEnumerable<(CompareStatus, PalletErrorMetadataV9)> CompareModuleErrorsV9(
            IEnumerable<PalletErrorMetadataV9>? source,
            IEnumerable<PalletErrorMetadataV9>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV9 storage))> CompareModuleStorageV9(
            PalletStorageMetadataV9 source,
            PalletStorageMetadataV9 destination)
        {
            if (source.Prefix.Value != destination.Prefix.Value)
                throw new InvalidOperationException("Source and Destination prefix should be equals !");

            var res = NameDiff(
                Sanitize(source.Entries),
                Sanitize(destination.Entries))
                .Select(x => (source.Prefix.Value, x));

            return res;
        }

        #endregion

        #region Compare V10
        public Task<MetadataDiffV10> MetadataCompareV10Async(MetadataV10 m1, MetadataV10 m2)
        {
            var resModulesDiff = new List<MetadataDifferentialModulesV10>();

            // Check added / removed pallet
            var nonCommonModules = NameDiff(Sanitize(m1.RuntimeMetadataData.Modules), Sanitize(m2.RuntimeMetadataData.Modules));

            resModulesDiff.AddRange(nonCommonModules.Select(x => x.Item2.ToDifferentialModules(x.Item1)));

            // We insert added modules
            var m1CommonModules = FilterModuleByStatus(m1.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Removed);
            var m2CommonModules = FilterModuleByStatus(m2.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Added);

            if (m1CommonModules.Count() != m2CommonModules.Count()) throw new InvalidOperationException("Metadata modules should be equals !");

            foreach (var elem in m1CommonModules.Zip(m2CommonModules))
            {
                resModulesDiff.Add(new MetadataDifferentialModulesV10()
                {
                    ModuleName = elem.First.Name.Value,
                    Storage = CompareModuleStorageV10(elem.First.Storage.Value, elem.Second.Storage.Value),
                    Calls = CompareModuleCallsV10(Sanitize(elem.First.Calls), Sanitize(elem.Second.Calls)),
                    Events = CompareModuleEventsV10(Sanitize(elem.First.Events), Sanitize(elem.Second.Events)),
                    Constants = CompareModuleConstantsV10(Sanitize(elem.First.Constants), Sanitize(elem.Second.Constants)),
                    Errors = CompareModuleErrorsV10(Sanitize(elem.First.Errors), Sanitize(elem.Second.Errors))
                });
            }

            return Task.FromResult(new MetadataDiffV10()
            {
                AllModulesDiff = resModulesDiff
            });
        }

        public IEnumerable<(CompareStatus, PalletCallMetadataV10)> CompareModuleCallsV10(BaseVec<ModuleMetadataV10> source, BaseVec<ModuleMetadataV10> destination)
            => CompareModuleCallsV10(
                Sanitize(source.Value.Select(x => x.Calls)),
                Sanitize(destination.Value.Select(x => x.Calls)));

        public IEnumerable<(CompareStatus, PalletCallMetadataV10)> CompareModuleCallsV10(
            IEnumerable<PalletCallMetadataV10>? source,
            IEnumerable<PalletCallMetadataV10>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);


        public IEnumerable<(CompareStatus, PalletEventMetadataV10)> CompareModuleEventsV10(BaseVec<ModuleMetadataV10> source, BaseVec<ModuleMetadataV10> destination)
            => CompareModuleEventsV10(
                Sanitize(source.Value.Select(x => x.Events)),
                Sanitize(destination.Value.Select(x => x.Events)));

        public IEnumerable<(CompareStatus, PalletEventMetadataV10)> CompareModuleEventsV10(
            IEnumerable<PalletEventMetadataV10>? source,
            IEnumerable<PalletEventMetadataV10>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletConstantMetadataV10)> CompareModuleConstantsV10(BaseVec<ModuleMetadataV10> source, BaseVec<ModuleMetadataV10> destination)
            => CompareModuleConstantsV10(
                Sanitize(source.Value.Select(x => x.Constants)),
                Sanitize(destination.Value.Select(x => x.Constants)));

        public IEnumerable<(CompareStatus, PalletConstantMetadataV10)> CompareModuleConstantsV10(
            IEnumerable<PalletConstantMetadataV10>? source,
            IEnumerable<PalletConstantMetadataV10>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletErrorMetadataV10)> CompareModuleErrorsV10(BaseVec<ModuleMetadataV10> source, BaseVec<ModuleMetadataV10> destination)
            => CompareModuleErrorsV10(
                Sanitize(source.Value.Select(x => x.Errors)),
                Sanitize(destination.Value.Select(x => x.Errors)));


        public IEnumerable<(CompareStatus, PalletErrorMetadataV10)> CompareModuleErrorsV10(
            IEnumerable<PalletErrorMetadataV10>? source,
            IEnumerable<PalletErrorMetadataV10>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV10 storage))> CompareModuleStorageV10(
            PalletStorageMetadataV10? source,
            PalletStorageMetadataV10? destination)
        {
            if (source == null && destination == null)
                return Enumerable.Empty<(string prefix, (CompareStatus status, StorageEntryMetadataV10 storage))>();

            string prefix = source != null ? source.Prefix.Value : destination!.Prefix.Value;

            return NameDiff(
                source != null ? Sanitize(source.Entries) : null,
                destination != null ? Sanitize(destination.Entries) : null)
                .Select(x => (prefix, x));
        }
        #endregion

        #region Compare V11
        public Task<MetadataDiffV11> MetadataCompareV11Async(MetadataV11 m1, MetadataV11 m2)
        {
            var resModulesDiff = new List<MetadataDifferentialModulesV11>();

            // Check added / removed pallet
            var nonCommonModules = NameDiff(Sanitize(m1.RuntimeMetadataData.Modules), Sanitize(m2.RuntimeMetadataData.Modules));

            resModulesDiff.AddRange(nonCommonModules.Select(x => x.Item2.ToDifferentialModule(x.Item1)));

            // We insert added modules
            var m1CommonModules = FilterModuleByStatus(m1.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Removed);
            var m2CommonModules = FilterModuleByStatus(m2.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Added);

            if (m1CommonModules.Count() != m2CommonModules.Count()) throw new InvalidOperationException("Metadata modules should be equals !");

            foreach (var elem in m1CommonModules.Zip(m2CommonModules))
            {
                resModulesDiff.Add(new MetadataDifferentialModulesV11()
                {
                    ModuleName = elem.First.Name.Value,
                    Storage = CompareModuleStorageV11(elem.First.Storage.Value, elem.Second.Storage.Value),
                    Calls = CompareModuleCallsV11(Sanitize(elem.First.Calls), Sanitize(elem.Second.Calls)),
                    Events = CompareModuleEventsV11(Sanitize(elem.First.Events), Sanitize(elem.Second.Events)),
                    Constants = CompareModuleConstantsV11(Sanitize(elem.First.Constants), Sanitize(elem.Second.Constants)),
                    Errors = CompareModuleErrorsV11(Sanitize(elem.First.Errors), Sanitize(elem.Second.Errors))
                });
            }

            return Task.FromResult(new MetadataDiffV11()
            {
                AllModulesDiff = resModulesDiff
            });
        }

        public IEnumerable<(CompareStatus, PalletCallMetadataV11)> CompareModuleCallsV11(BaseVec<ModuleMetadataV11> source, BaseVec<ModuleMetadataV11> destination)
            => CompareModuleCallsV11(
                Sanitize(source.Value.Select(x => x.Calls)),
                Sanitize(destination.Value.Select(x => x.Calls)));

        public IEnumerable<(CompareStatus, PalletCallMetadataV11)> CompareModuleCallsV11(
            IEnumerable<PalletCallMetadataV11>? source,
            IEnumerable<PalletCallMetadataV11>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);


        public IEnumerable<(CompareStatus, PalletEventMetadataV11)> CompareModuleEventsV11(BaseVec<ModuleMetadataV11> source, BaseVec<ModuleMetadataV11> destination)
            => CompareModuleEventsV11(
                Sanitize(source.Value.Select(x => x.Events)),
                Sanitize(destination.Value.Select(x => x.Events)));

        public IEnumerable<(CompareStatus, PalletEventMetadataV11)> CompareModuleEventsV11(
            IEnumerable<PalletEventMetadataV11>? source,
            IEnumerable<PalletEventMetadataV11>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletConstantMetadataV11)> CompareModuleConstantsV11(BaseVec<ModuleMetadataV11> source, BaseVec<ModuleMetadataV11> destination)
            => CompareModuleConstantsV11(
                Sanitize(source.Value.Select(x => x.Constants)),
                Sanitize(destination.Value.Select(x => x.Constants)));

        public IEnumerable<(CompareStatus, PalletConstantMetadataV11)> CompareModuleConstantsV11(
            IEnumerable<PalletConstantMetadataV11>? source,
            IEnumerable<PalletConstantMetadataV11>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletErrorMetadataV11)> CompareModuleErrorsV11(BaseVec<ModuleMetadataV11> source, BaseVec<ModuleMetadataV11> destination)
            => CompareModuleErrorsV11(
                Sanitize(source.Value.Select(x => x.Errors)),
                Sanitize(destination.Value.Select(x => x.Errors)));


        public IEnumerable<(CompareStatus, PalletErrorMetadataV11)> CompareModuleErrorsV11(
            IEnumerable<PalletErrorMetadataV11>? source,
            IEnumerable<PalletErrorMetadataV11>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV11 storage))> CompareModuleStorageV11(
            PalletStorageMetadataV11? source,
            PalletStorageMetadataV11? destination)
        {
            if (source == null && destination == null)
                return Enumerable.Empty<(string prefix, (CompareStatus status, StorageEntryMetadataV11 storage))>();

            string prefix = source != null ? source.Prefix.Value : destination!.Prefix.Value;

            return NameDiff(
                source != null ? Sanitize(source.Entries) : null,
                destination != null ? Sanitize(destination.Entries) : null)
                .Select(x => (prefix, x));
        }
        #endregion

        #region Compare V12
        public Task<MetadataDiffV12> MetadataCompareV12Async(MetadataV12 m1, MetadataV12 m2)
        {
            var resModulesDiff = new List<MetadataDifferentialModulesV12>();

            // Check added / removed pallet
            var nonCommonModules = NameDiff(Sanitize(m1.RuntimeMetadataData.Modules), Sanitize(m2.RuntimeMetadataData.Modules));

            resModulesDiff.AddRange(nonCommonModules.Select(x => x.Item2.ToDifferentialModules(x.Item1)));

            // We insert added modules
            var m1CommonModules = FilterModuleByStatus(m1.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Removed);
            var m2CommonModules = FilterModuleByStatus(m2.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Added);

            if (m1CommonModules.Count() != m2CommonModules.Count()) throw new InvalidOperationException("Metadata modules should be equals !");

            foreach (var elem in m1CommonModules.Zip(m2CommonModules))
            {
                resModulesDiff.Add(new MetadataDifferentialModulesV12()
                {
                    ModuleName = elem.First.Name.Value,
                    Storage = CompareModuleStorageV12(elem.First.Storage.Value, elem.Second.Storage.Value),
                    Calls = CompareModuleCallsV12(Sanitize(elem.First.Calls), Sanitize(elem.Second.Calls)),
                    Events = CompareModuleEventsV12(Sanitize(elem.First.Events), Sanitize(elem.Second.Events)),
                    Constants = CompareModuleConstantsV12(Sanitize(elem.First.Constants), Sanitize(elem.Second.Constants)),
                    Errors = CompareModuleErrorsV12(Sanitize(elem.First.Errors), Sanitize(elem.Second.Errors))
                });
            }

            return Task.FromResult(new MetadataDiffV12()
            {
                AllModulesDiff = resModulesDiff
            });
        }

        public IEnumerable<(CompareStatus, PalletCallMetadataV12)> CompareModuleCallsV12(BaseVec<ModuleMetadataV12> source, BaseVec<ModuleMetadataV12> destination)
            => CompareModuleCallsV12(
                Sanitize(source.Value.Select(x => x.Calls)),
                Sanitize(destination.Value.Select(x => x.Calls)));

        public IEnumerable<(CompareStatus, PalletCallMetadataV12)> CompareModuleCallsV12(
            IEnumerable<PalletCallMetadataV12>? source,
            IEnumerable<PalletCallMetadataV12>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);


        public IEnumerable<(CompareStatus, PalletEventMetadataV12)> CompareModuleEventsV12(BaseVec<ModuleMetadataV12> source, BaseVec<ModuleMetadataV12> destination)
            => CompareModuleEventsV12(
                Sanitize(source.Value.Select(x => x.Events)),
                Sanitize(destination.Value.Select(x => x.Events)));

        public IEnumerable<(CompareStatus, PalletEventMetadataV12)> CompareModuleEventsV12(
            IEnumerable<PalletEventMetadataV12>? source,
            IEnumerable<PalletEventMetadataV12>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletConstantMetadataV12)> CompareModuleConstantsV12(BaseVec<ModuleMetadataV12> source, BaseVec<ModuleMetadataV12> destination)
            => CompareModuleConstantsV12(
                Sanitize(source.Value.Select(x => x.Constants)),
                Sanitize(destination.Value.Select(x => x.Constants)));

        public IEnumerable<(CompareStatus, PalletConstantMetadataV12)> CompareModuleConstantsV12(
            IEnumerable<PalletConstantMetadataV12>? source,
            IEnumerable<PalletConstantMetadataV12>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletErrorMetadataV12)> CompareModuleErrorsV12(BaseVec<ModuleMetadataV12> source, BaseVec<ModuleMetadataV12> destination)
            => CompareModuleErrorsV12(
                Sanitize(source.Value.Select(x => x.Errors)),
                Sanitize(destination.Value.Select(x => x.Errors)));


        public IEnumerable<(CompareStatus, PalletErrorMetadataV12)> CompareModuleErrorsV12(
            IEnumerable<PalletErrorMetadataV12>? source,
            IEnumerable<PalletErrorMetadataV12>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV11 storage))> CompareModuleStorageV12(
            PalletStorageMetadataV12? source,
            PalletStorageMetadataV12? destination)
        {
            if (source == null && destination == null)
                return Enumerable.Empty<(string prefix, (CompareStatus status, StorageEntryMetadataV11 storage))>();

            string prefix = source != null ? source.Prefix.Value : destination!.Prefix.Value;

            return NameDiff(
                source != null ? Sanitize(source.Entries) : null,
                destination != null ? Sanitize(destination.Entries) : null)
                .Select(x => (prefix, x));
        }
        #endregion

        #region Compare V13
        public Task<MetadataDiffV13> MetadataCompareV13Async(MetadataV13 m1, MetadataV13 m2)
        {
            var resModulesDiff = new List<MetadataDifferentialModulesV13>();

            // Check added / removed pallet
            var nonCommonModules = NameDiff(Sanitize(m1.RuntimeMetadataData.Modules), Sanitize(m2.RuntimeMetadataData.Modules));

            resModulesDiff.AddRange(nonCommonModules.Select(x => x.Item2.ToDifferentialModules(x.Item1)));

            // We insert added modules
            var m1CommonModules = FilterModuleByStatus(m1.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Removed);
            var m2CommonModules = FilterModuleByStatus(m2.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Added);

            if (m1CommonModules.Count() != m2CommonModules.Count()) throw new InvalidOperationException("Metadata modules should be equals !");

            foreach (var elem in m1CommonModules.Zip(m2CommonModules))
            {
                resModulesDiff.Add(new MetadataDifferentialModulesV13()
                {
                    ModuleName = elem.First.Name.Value,
                    Storage = CompareModuleStorageV13(elem.First.Storage.Value, elem.Second.Storage.Value),
                    Calls = CompareModuleCallsV13(Sanitize(elem.First.Calls), Sanitize(elem.Second.Calls)),
                    Events = CompareModuleEventsV13(Sanitize(elem.First.Events), Sanitize(elem.Second.Events)),
                    Constants = CompareModuleConstantsV13(Sanitize(elem.First.Constants), Sanitize(elem.Second.Constants)),
                    Errors = CompareModuleErrorsV13(Sanitize(elem.First.Errors), Sanitize(elem.Second.Errors))
                });
            }

            return Task.FromResult(new MetadataDiffV13()
            {
                AllModulesDiff = resModulesDiff
            });
        }

        public IEnumerable<(CompareStatus, PalletCallMetadataV13)> CompareModuleCallsV13(BaseVec<ModuleMetadataV13> source, BaseVec<ModuleMetadataV13> destination)
            => CompareModuleCallsV13(
                Sanitize(source.Value.Select(x => x.Calls)),
                Sanitize(destination.Value.Select(x => x.Calls)));

        public IEnumerable<(CompareStatus, PalletCallMetadataV13)> CompareModuleCallsV13(
            IEnumerable<PalletCallMetadataV13>? source,
            IEnumerable<PalletCallMetadataV13>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);


        public IEnumerable<(CompareStatus, PalletEventMetadataV13)> CompareModuleEventsV13(BaseVec<ModuleMetadataV13> source, BaseVec<ModuleMetadataV13> destination)
            => CompareModuleEventsV13(
                Sanitize(source.Value.Select(x => x.Events)),
                Sanitize(destination.Value.Select(x => x.Events)));

        public IEnumerable<(CompareStatus, PalletEventMetadataV13)> CompareModuleEventsV13(
            IEnumerable<PalletEventMetadataV13>? source,
            IEnumerable<PalletEventMetadataV13>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletConstantMetadataV13)> CompareModuleConstantsV13(BaseVec<ModuleMetadataV13> source, BaseVec<ModuleMetadataV13> destination)
            => CompareModuleConstantsV13(
                Sanitize(source.Value.Select(x => x.Constants)),
                Sanitize(destination.Value.Select(x => x.Constants)));

        public IEnumerable<(CompareStatus, PalletConstantMetadataV13)> CompareModuleConstantsV13(
            IEnumerable<PalletConstantMetadataV13>? source,
            IEnumerable<PalletConstantMetadataV13>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletErrorMetadataV13)> CompareModuleErrorsV13(BaseVec<ModuleMetadataV13> source, BaseVec<ModuleMetadataV13> destination)
            => CompareModuleErrorsV13(
                Sanitize(source.Value.Select(x => x.Errors)),
                Sanitize(destination.Value.Select(x => x.Errors)));


        public IEnumerable<(CompareStatus, PalletErrorMetadataV13)> CompareModuleErrorsV13(
            IEnumerable<PalletErrorMetadataV13>? source,
            IEnumerable<PalletErrorMetadataV13>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV13 storage))> CompareModuleStorageV13(
            PalletStorageMetadataV13? source,
            PalletStorageMetadataV13? destination)
        {
            if (source == null && destination == null)
                return Enumerable.Empty<(string prefix, (CompareStatus status, StorageEntryMetadataV13 storage))>();

            string prefix = source != null ? source.Prefix.Value : destination!.Prefix.Value;

            return NameDiff(
                source != null ? Sanitize(source.Entries) : null,
                destination != null ? Sanitize(destination.Entries) : null)
                .Select(x => (prefix, x));
        }
        #endregion

        #region Compare V14
        public Task<MetadataDiffV14> MetadataCompareV14Async(MetadataV14 m1, MetadataV14 m2)
        {
            var resModulesDiff = new List<MetadataDifferentialModulesV14>();

            // Check added / removed pallet
            var nonCommonModules = NameDiff(Sanitize(m1.RuntimeMetadataData.Modules), Sanitize(m2.RuntimeMetadataData.Modules));


            resModulesDiff.AddRange(nonCommonModules.Select(x =>
            {
                if (x.Item1 == CompareStatus.Added)
                    return x.Item2.ToDifferentialModules(x.Item1, m2.RuntimeMetadataData.Lookup);
                else
                    return x.Item2.ToDifferentialModules(x.Item1, m1.RuntimeMetadataData.Lookup);


            }));

            // We insert added modules
            var m1CommonModules = FilterModuleByStatus(m1.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Removed);
            var m2CommonModules = FilterModuleByStatus(m2.RuntimeMetadataData.Modules.Value, nonCommonModules, CompareStatus.Added);

            if (m1CommonModules.Count() != m2CommonModules.Count()) throw new InvalidOperationException("Metadata modules should be equals !");

            foreach (var elem in m1CommonModules.Zip(m2CommonModules))
            {
                resModulesDiff.Add(new MetadataDifferentialModulesV14()
                {
                    ModuleName = elem.First.Name.Value,
                    Storage = CompareModuleStorageV14(elem.First.Storage.Value, elem.Second.Storage.Value),
                    Calls = CompareModuleV14(elem.First.Calls, elem.Second.Calls, m1.RuntimeMetadataData.Lookup, m2.RuntimeMetadataData.Lookup),
                    Events = CompareModuleV14(elem.First.Events, elem.Second.Events, m1.RuntimeMetadataData.Lookup, m2.RuntimeMetadataData.Lookup),
                    Constants = CompareModuleConstantsV14(Sanitize(elem.First.Constants), Sanitize(elem.Second.Constants)),
                    Errors = CompareModuleV14(elem.First.Errors, elem.Second.Errors, m1.RuntimeMetadataData.Lookup, m2.RuntimeMetadataData.Lookup)
                });
            }

            return Task.FromResult(new MetadataDiffV14()
            {
                AllModulesDiff = resModulesDiff
            });
        }

        //public IEnumerable<(CompareStatus, PalletCallMetadataV14)> CompareModuleCallsV14(BaseOpt<ModuleMetadataV14> source, BaseOpt<ModuleMetadataV14> destination)
        //    => CompareModuleCallsV14(
        //        Sanitize(source.Value.Select(x => x.Calls)),
        //        Sanitize(destination.Value.Select(x => x.Calls)));

        public LookupDifferential CompareModuleV14<T>(
            BaseOpt<T> source,
            BaseOpt<T> destination,
            PortableRegistry lookupSource,
            PortableRegistry lookupDestination)
            where T : BaseType, IMetadataType, new()
        {
            if (!source.OptionFlag && !destination.OptionFlag)
                return new LookupDifferential();

            if (source.OptionFlag && !destination.OptionFlag)
                return LookupDifferential.FromLookup(CompareStatus.Removed, LookupDifferential.FindType(lookupSource, source.Value.ItemType));

            if (!source.OptionFlag && destination.OptionFlag)
                return LookupDifferential.FromLookup(CompareStatus.Added, LookupDifferential.FindType(lookupDestination, destination.Value.ItemType));

            return CompareLookup(source.Value.ItemType, destination.Value.ItemType, lookupSource, lookupDestination);
        }

        //public LookupDifferential CompareModuleCallsV14(
        //    BaseOpt<PalletCallMetadataV14> source,
        //    BaseOpt<PalletCallMetadataV14> destination,
        //    PortableRegistry lookupSource,
        //    PortableRegistry lookupDestination)
        //{
        //    return CompareModuleV14(source, destination, lookupSource, lookupDestination);
        //}

        //public IEnumerable<LookupDifferential> CompareModuleEventsV14(
        //    BaseOpt<PalletEventMetadataV14> source,
        //    BaseOpt<PalletEventMetadataV14> destination,
        //    PortableRegistry lookupSource,
        //    PortableRegistry lookupDestination)
        //{
        //    return CompareModuleV14(source, destination, lookupSource, lookupDestination);
        //}

        //public IEnumerable<LookupDifferential> CompareModuleErrorsV14(
        //    BaseOpt<PalletErrorMetadataV14> source,
        //    BaseOpt<PalletErrorMetadataV14> destination,
        //    PortableRegistry lookupSource,
        //    PortableRegistry lookupDestination)
        //{
        //    if (!source.OptionFlag && !destination.OptionFlag) return new List<LookupDifferential>();
        //    if (source.OptionFlag && !destination.OptionFlag) return new List<LookupDifferential>() {
        //        LookupDifferential.FromLookup(CompareStatus.Removed, LookupDifferential.FindType(lookupSource, source.Value.ErrorType))
        //    };

        //    if (!source.OptionFlag && destination.OptionFlag) return new List<LookupDifferential>() {
        //        LookupDifferential.FromLookup(CompareStatus.Added, LookupDifferential.FindType(lookupDestination, destination.Value.ErrorType))
        //    };

        //    return new List<LookupDifferential>() {
        //        CompareLookup(source.Value.ErrorType, destination.Value.ErrorType, lookupSource, lookupDestination)
        //    };
        //}


        //public IEnumerable<(CompareStatus, PalletEventMetadataV14)> CompareModuleEventsV14(BaseVec<ModuleMetadataV14> source, BaseVec<ModuleMetadataV14> destination)
        //    => CompareModuleEventsV14(
        //        Sanitize(source.Value.Select(x => x.Events)),
        //        Sanitize(destination.Value.Select(x => x.Events)));

        //public IEnumerable<(CompareStatus, PalletEventMetadataV14)> CompareModuleEventsV14(
        //    IEnumerable<PalletEventMetadataV14>? source,
        //    IEnumerable<PalletEventMetadataV14>? destination)
        //    => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(CompareStatus, PalletConstantMetadataV14)> CompareModuleConstantsV14(BaseVec<ModuleMetadataV14> source, BaseVec<ModuleMetadataV14> destination)
            => CompareModuleConstantsV14(
                Sanitize(source.Value.Select(x => x.Constants)),
                Sanitize(destination.Value.Select(x => x.Constants)));

        public IEnumerable<(CompareStatus, PalletConstantMetadataV14)> CompareModuleConstantsV14(
            IEnumerable<PalletConstantMetadataV14>? source,
            IEnumerable<PalletConstantMetadataV14>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        //public IEnumerable<(CompareStatus, PalletErrorMetadataV14)> CompareModuleErrorsV14(BaseVec<ModuleMetadataV14> source, BaseVec<ModuleMetadataV14> destination)
        //    => CompareModuleErrorsV14(
        //        Sanitize(source.Value.Select(x => x.Errors)),
        //        Sanitize(destination.Value.Select(x => x.Errors)));


        //public IEnumerable<(CompareStatus, PalletErrorMetadataV14)> CompareModuleErrorsV14(
        //    IEnumerable<PalletErrorMetadataV14>? source,
        //    IEnumerable<PalletErrorMetadataV14>? destination)
        //    => MetadataModuleCompare(source, destination, (x, y) => x.Name.Value == y.Name.Value);

        public IEnumerable<(string prefix, (CompareStatus status, StorageEntryMetadataV14 storage))> CompareModuleStorageV14(
            PalletStorageMetadataV14? source,
            PalletStorageMetadataV14? destination)
        {
            if (source == null && destination == null)
                return Enumerable.Empty<(string prefix, (CompareStatus status, StorageEntryMetadataV14 storage))>();

            string prefix = source != null ? source.Prefix.Value : destination!.Prefix.Value;

            return NameDiff(
                source != null ? Sanitize(source.Entries) : null,
                destination != null ? Sanitize(destination.Entries) : null)
                .Select(x => (prefix, x));
        }

        public LookupDifferential CompareLookup(TType idSource, TType idDestination, PortableRegistry lookupSource, PortableRegistry lookupDestination)
            => CompareLookup((uint)idSource.Value.Value, (uint)idDestination.Value.Value, lookupSource, lookupDestination);

        public LookupDifferential CompareLookup(
            uint idSource, uint idDestination, PortableRegistry lookupSource, PortableRegistry lookupDestination)
        {
            var result = new LookupDifferential();

            Guard.Against.NegativeOrZero(idSource);
            Guard.Against.NegativeOrZero(idDestination);

            var typeSource = lookupSource.Value.Single(x => x.Id.Value == idSource);
            var typeDestination = lookupDestination.Value.Single(x => x.Id.Value == idDestination);

            result.Id = CompareId(typeSource, typeDestination);
            result.Path = ComparePath(typeSource, typeDestination);
            result.Params = CompareParams(typeSource, typeDestination);
            result.LookupDifferentialType = CompareTypeDef(typeSource, typeDestination);
            result.Docs = CompareDocs(typeSource, typeDestination);

            return result;

        }

        private IList<(CompareStatus status, U32 docs)> CompareId(PortableType typeSource, PortableType typeDestination)
        {
            var res = new List<(CompareStatus status, U32 docs)>();
            if (typeSource.Id.Value != typeDestination.Id.Value)
            {
                res = new()
                {
                    (CompareStatus.Removed, typeSource.Id),
                    (CompareStatus.Added, typeDestination.Id)
                };
            }

            return res;
        }

        private IList<(CompareStatus status, BaseVec<Str> docs)> ComparePath(PortableType typeSource, PortableType typeDestination)
        {
            var res = new List<(CompareStatus status, BaseVec<Str> docs)>();
            if (!AreStringsEquals(typeSource.Ty.Path, typeDestination.Ty.Path))
            {
                res = new()
                {
                    (CompareStatus.Removed, typeSource.Ty.Path),
                    (CompareStatus.Added, typeDestination.Ty.Path)
                };
            }

            return res;
        }

        private IList<(CompareStatus status, BaseVec<TypeParameter> param)> CompareParams(PortableType typeSource, PortableType typeDestination)
        {
            var res = new List<(CompareStatus status, BaseVec<TypeParameter> param)>();

            if (!AreStringsEquals(
                typeSource.Ty.TypeParams.Value.Select(x => x.Name),
                typeDestination.Ty.TypeParams.Value.Select(x => x.Name)))
            {
                res = new()
                {
                    (CompareStatus.Removed, typeSource.Ty.TypeParams),
                    (CompareStatus.Added, typeDestination.Ty.TypeParams)
                };
            }

            return res;
        }

        private LookupDifferentialTypeDef CompareTypeDef(PortableType typeSource, PortableType typeDestination)
        {
            var result = new LookupDifferentialTypeDef();
            if (typeSource.Ty.TypeDef.Value != typeDestination.Ty.TypeDef.Value)
            {
                LookupDifferential.AddTypeDefAction(result, CompareStatus.Removed, typeSource);
                LookupDifferential.AddTypeDefAction(result, CompareStatus.Added, typeDestination);
            }
            else
            {
                // We got the same type, let's check if methods has been added or removed
                switch (typeSource.Ty.TypeDef.Value)
                {
                    case TypeDefEnum.Composite:
                        result.TypeComposite = CompareComposite(
                                (TypeDefComposite)typeSource.Ty.TypeDef.Value2,
                                (TypeDefComposite)typeDestination.Ty.TypeDef.Value2);
                        break;
                    case TypeDefEnum.Variant:
                        result.TypeVariant = new DifferentialVariant()
                        {
                            Elems = CompareVariant(
                                (TypeDefVariant)typeSource.Ty.TypeDef.Value2,
                                (TypeDefVariant)typeDestination.Ty.TypeDef.Value2)
                        };
                        break;
                    case TypeDefEnum.Sequence:
                        var sequenceSource = (TypeDefSequence)typeSource.Ty.TypeDef.Value2;
                        var sequenceDestination = (TypeDefSequence)typeDestination.Ty.TypeDef.Value2;
                        if (sequenceSource.TypeParam != sequenceDestination.TypeParam)
                        {
                            result.TypeSequence.Add((CompareStatus.Removed, sequenceSource));
                            result.TypeSequence.Add((CompareStatus.Added, sequenceDestination));
                        }
                        break;
                    case TypeDefEnum.Array:
                        result.TypeArray = CompareTypeBased(
                            (TypeDefArray)typeSource.Ty.TypeDef.Value2, 
                            (TypeDefArray)typeDestination.Ty.TypeDef.Value2);
                        break;
                    case TypeDefEnum.Primitive:
                        var primSource = (BaseEnum<TypeDefPrimitive>)typeSource.Ty.TypeDef.Value2;
                        var primDestination = (BaseEnum<TypeDefPrimitive>)typeDestination.Ty.TypeDef.Value2;
                        if (primSource.Value != primDestination.Value)
                        {
                            result.TypePrimitive.Add((CompareStatus.Removed, primSource));
                            result.TypePrimitive.Add((CompareStatus.Added, primDestination));
                        }
                        break;
                    case TypeDefEnum.Compact:
                        result.TypeCompact = CompareTypeBased(
                            (TypeDefCompact)typeSource.Ty.TypeDef.Value2, 
                            (TypeDefCompact)typeDestination.Ty.TypeDef.Value2);
                        break;
                    case TypeDefEnum.BitSequence:
                        result.TypeSequence = CompareTypeBased(
                            (TypeDefSequence)typeSource.Ty.TypeDef.Value2,
                            (TypeDefSequence)typeDestination.Ty.TypeDef.Value2);
                        break;
                    case TypeDefEnum.Tuple:
                        result.TypeTuple = CompareTuple(
                            (TypeDefTuple)typeSource.Ty.TypeDef.Value2,
                            (TypeDefTuple)typeDestination.Ty.TypeDef.Value2);
                        break;
                    default:
                        throw new NotImplementedException("TypeDefEnum not implemented !?");
                }

            }
            return result;
        }

        private IList<(CompareStatus, T)> CompareTypeBased<T>(T source, T destination)
            where T : BaseType, IMetadataType, new()
        {
            if (source.ItemType != destination.ItemType)
            {
                return new List<(CompareStatus, T)>()
                {
                    (CompareStatus.Removed, source),
                    (CompareStatus.Added, destination)
                };
            }

            return new List<(CompareStatus, T)>();
        }

        private DifferentialComposite CompareComposite(TypeDefComposite source, TypeDefComposite destination)
        {
            return new DifferentialComposite()
            {
                Elems = TypeDiff(Sanitize(source.Fields), Sanitize(destination.Fields))
            };
        }

        private IEnumerable<(CompareStatus, Variant)> CompareVariant(TypeDefVariant variantSource, TypeDefVariant variantDestination)
        {
            var res = NameDiff(variantSource.TypeParam.Value, variantDestination.TypeParam.Value);

            return res;
        }

        private DifferentialTuple CompareTuple(TypeDefTuple source, TypeDefTuple destination)
        {
            return new DifferentialTuple()
            {
                Elems = TypeDiff(Sanitize(source.Fields), Sanitize(destination.Fields))
            };
        }

        private IList<(CompareStatus status, BaseVec<Str> docs)> CompareDocs(PortableType typeSource, PortableType typeDestination)
        {
            var res = new List<(CompareStatus status, BaseVec<Str> docs)>();
            if (!AreStringsEquals(typeSource.Ty.Docs, typeDestination.Ty.Docs))
            {
                res = new()
                {
                    (CompareStatus.Removed, typeSource.Ty.Docs),
                    (CompareStatus.Added, typeDestination.Ty.Docs)
                };
            }
            return res;
        }


        #endregion
    }
}
