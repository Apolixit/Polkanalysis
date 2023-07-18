using Ardalis.GuardClauses;
using MediatR.Wrappers;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Polkanalysis.Domain.Contracts.Service;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Service
{
    public class MetadataService : IMetadataService
    {
        public Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, int specVersion1, int specVersion2)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, string hexMetadata1, string hexMetadata2)
        {
            throw new NotImplementedException();
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

        //public Task<MetadataDiffV9> MetadataCompareV9Async(string hexMetadata1, string hexMetadata2)
        //{
        //    Guard.Against.NullOrEmpty(hexMetadata1);
        //    Guard.Against.NullOrEmpty(hexMetadata2);

        //    // To be compared, Metadata should have same Major version
        //    CheckRuntimeMetadata checkVersion1 = new(hexMetadata1);
        //    CheckRuntimeMetadata checkVersion2 = new(hexMetadata2);

        //    if (checkVersion1.MetaDataInfo.Version.Value != checkVersion2.MetaDataInfo.Version.Value)
        //        throw new InvalidOperationException($"Cannot compare metadata v{checkVersion1.MetaDataInfo.Version.Value} and v{checkVersion2.MetaDataInfo.Version.Value}. Major version have to be the same.");

        //    var m1 = new MetadataV9();
        //    m1.Create(hexMetadata1);

        //    var m2 = new MetadataV9();
        //    m2.Create(hexMetadata2);

        //    return MetadataCompareV9Async(m1, m2);
        //}

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

        private IEnumerable<T> Sanitize<T>(IEnumerable<BaseOpt<BaseVec<T>>> elems)
            where T : IType, new()
        {
            if(elems == null) return Enumerable.Empty<T>();

            var res = elems
                .Where(x => x.OptionFlag)
                .SelectMany(x => x.Value.Value);

            return res;
        }

        private IEnumerable<T> Sanitize<T>(IEnumerable<BaseOpt<T>> elems)
            where T : IType, new()
        {
            if (elems == null) return Enumerable.Empty<T>();

            var res = elems
                .Where(x => x.OptionFlag)
                .Select(x => x.Value);

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
        #endregion

        #region Compare V9
        public Task<MetadataDiffV9> MetadataCompareV9Async(MetadataV9 m1, MetadataV9 m2)
        {
            return Task.FromResult(new MetadataDiffV9()
            {
                Storage = CompareModuleStorageV9(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Calls = CompareModuleCallsV9(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Events = CompareModuleEventsV9(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Constants = CompareModuleConstantsV9(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Errors = CompareModuleErrorsV9(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules)
            });
        }

        public IEnumerable<(CompareStatus, PalletCallMetadataV9)> CompareModuleCallsV9(BaseVec<ModuleMetadataV9> source, BaseVec<ModuleMetadataV9> destination)
            => CompareModuleCallsV9(
                Sanitize(source.Value.Select(x => x.Calls)),
                Sanitize(destination.Value.Select(x => x.Calls)));

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

        public IEnumerable<(CompareStatus, PalletStorageMetadataV9)> CompareModuleStorageV9(BaseVec<ModuleMetadataV9> source, BaseVec<ModuleMetadataV9> destination)
            => CompareModuleStorageV9(
                Sanitize(source.Value.Select(x => x.Storage)),
                Sanitize(destination.Value.Select(x => x.Storage)));

        public IEnumerable<(CompareStatus, PalletStorageMetadataV9)> CompareModuleStorageV9(
            IEnumerable<PalletStorageMetadataV9>? source,
            IEnumerable<PalletStorageMetadataV9>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Prefix.Value == y.Prefix.Value);
        #endregion

        #region Compare V10
        public Task<MetadataDiffV10> MetadataCompareV10Async(MetadataV10 m1, MetadataV10 m2)
        {
            return Task.FromResult(new MetadataDiffV10()
            {
                Storage = CompareModuleStorageV10(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Calls = CompareModuleCallsV10(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Events = CompareModuleEventsV10(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Constants = CompareModuleConstantsV10(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Errors = CompareModuleErrorsV10(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules)
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

        public IEnumerable<(CompareStatus, PalletStorageMetadataV10)> CompareModuleStorageV10(BaseVec<ModuleMetadataV10> source, BaseVec<ModuleMetadataV10> destination)
            => CompareModuleStorageV10(
                Sanitize(source.Value.Select(x => x.Storage)),
                Sanitize(destination.Value.Select(x => x.Storage)));

        public IEnumerable<(CompareStatus, PalletStorageMetadataV10)> CompareModuleStorageV10(
            IEnumerable<PalletStorageMetadataV10>? source,
            IEnumerable<PalletStorageMetadataV10>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Prefix.Value == y.Prefix.Value);
        #endregion

        #region Compare V11
        public Task<MetadataDiffV11> MetadataCompareV11Async(MetadataV11 m1, MetadataV11 m2)
        {
            return Task.FromResult(new MetadataDiffV11()
            {
                Storage = CompareModuleStorageV11(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Calls = CompareModuleCallsV11(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Events = CompareModuleEventsV11(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Constants = CompareModuleConstantsV11(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Errors = CompareModuleErrorsV11(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules)
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

        public IEnumerable<(CompareStatus, PalletStorageMetadataV11)> CompareModuleStorageV11(BaseVec<ModuleMetadataV11> source, BaseVec<ModuleMetadataV11> destination)
            => CompareModuleStorageV11(
                Sanitize(source.Value.Select(x => x.Storage)),
                Sanitize(destination.Value.Select(x => x.Storage)));

        public IEnumerable<(CompareStatus, PalletStorageMetadataV11)> CompareModuleStorageV11(
            IEnumerable<PalletStorageMetadataV11>? source,
            IEnumerable<PalletStorageMetadataV11>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Prefix.Value == y.Prefix.Value);
        #endregion

        #region Compare V12
        public Task<MetadataDiffV12> MetadataCompareV12Async(MetadataV12 m1, MetadataV12 m2)
        {
            return Task.FromResult(new MetadataDiffV12()
            {
                Storage = CompareModuleStorageV12(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Calls = CompareModuleCallsV12(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Events = CompareModuleEventsV12(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Constants = CompareModuleConstantsV12(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Errors = CompareModuleErrorsV12(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules)
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

        public IEnumerable<(CompareStatus, PalletStorageMetadataV12)> CompareModuleStorageV12(BaseVec<ModuleMetadataV12> source, BaseVec<ModuleMetadataV12> destination)
            => CompareModuleStorageV12(
                Sanitize(source.Value.Select(x => x.Storage)),
                Sanitize(destination.Value.Select(x => x.Storage)));

        public IEnumerable<(CompareStatus, PalletStorageMetadataV12)> CompareModuleStorageV12(
            IEnumerable<PalletStorageMetadataV12>? source,
            IEnumerable<PalletStorageMetadataV12>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Prefix.Value == y.Prefix.Value);
        #endregion

        #region Compare V13
        public Task<MetadataDiffV13> MetadataCompareV13Async(MetadataV13 m1, MetadataV13 m2)
        {
            return Task.FromResult(new MetadataDiffV13()
            {
                Storage = CompareModuleStorageV13(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Calls = CompareModuleCallsV13(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Events = CompareModuleEventsV13(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Constants = CompareModuleConstantsV13(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules),
                Errors = CompareModuleErrorsV13(m1.RuntimeMetadataData.Modules, m2.RuntimeMetadataData.Modules)
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

        public IEnumerable<(CompareStatus, PalletStorageMetadataV13)> CompareModuleStorageV13(BaseVec<ModuleMetadataV13> source, BaseVec<ModuleMetadataV13> destination)
            => CompareModuleStorageV13(
                Sanitize(source.Value.Select(x => x.Storage)),
                Sanitize(destination.Value.Select(x => x.Storage)));

        public IEnumerable<(CompareStatus, PalletStorageMetadataV13)> CompareModuleStorageV13(
            IEnumerable<PalletStorageMetadataV13>? source,
            IEnumerable<PalletStorageMetadataV13>? destination)
            => MetadataModuleCompare(source, destination, (x, y) => x.Prefix.Value == y.Prefix.Value);
        #endregion
    }
}
