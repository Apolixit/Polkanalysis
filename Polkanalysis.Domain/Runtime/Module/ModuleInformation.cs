﻿using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Domain.Runtime.Module
{
    public class ModuleInformation : IModuleInformation
    {
        private readonly ICurrentMetaData _currentMetaData;
        private readonly IModelBuilder _modelBuilder;
        private readonly ISubstrateService _substrateService;

        public ModuleInformation(ICurrentMetaData currentMetaData, IModelBuilder modelBuilder, ISubstrateService substrateService)
        {
            _currentMetaData = currentMetaData;
            _modelBuilder = modelBuilder;
            _substrateService = substrateService;
        }

        #region Calls
        public List<ModuleCallsDto> GetModuleCalls(string palletName)
            => GetModuleCalls(_currentMetaData.GetPalletModule(palletName));

        public List<ModuleCallsDto> GetModuleCalls(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleCallsDto = new List<ModuleCallsDto>();
            if (palletModule.Calls != null)
            {
                var nodeTypeCalls = _currentMetaData.GetPalletType(palletModule.Calls.TypeId);

                if (nodeTypeCalls is NodeTypeVariant moduleCalls)
                {
                    if (moduleCalls.Variants == null)
                    {
                        // TODO : warning log -> weird behavior
                        return moduleCallsDto;
                        //throw new InvalidOperationException($"Module variant calls from module {palletModule.Name} are null");
                    }

                    foreach (var moduleCall in moduleCalls.Variants)
                    {
                        var callDto = new ModuleCallsDto()
                        {
                            Name = moduleCall.Name,
                            Documentation = _modelBuilder.BuildDocumentation(moduleCall.Docs),
                            Lookup = moduleCall.Index,
                            NbParameter = moduleCall.TypeFields != null ? moduleCall.TypeFields.Length : 0,
                            Arguments = moduleCall.TypeFields != null ? moduleCall.TypeFields.Select(_currentMetaData.BuildTypeField).ToList() : null,
                        };
                        moduleCallsDto.Add(callDto);
                    }
                }
                else
                    throw new InvalidCastException($"Module calls from module {palletModule.Name} cannot be casted to NodeTypeVariant");
            }

            return moduleCallsDto;
        }
        #endregion

        #region Events
        public List<ModuleEventsDto> GetModuleEvents(string palletName)
                => GetModuleEvents(_currentMetaData.GetPalletModule(palletName));

        public List<ModuleEventsDto> GetModuleEvents(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleEventsDto = new List<ModuleEventsDto>();
            if (palletModule.Events != null)
            {
                var nodeTypeEvent = _currentMetaData.GetPalletType(palletModule.Events.TypeId);

                if (nodeTypeEvent is NodeTypeVariant moduleEvents)
                {
                    if (moduleEvents.Variants == null)
                    {
                        // TODO : warning log -> weird behavior
                        return moduleEventsDto;
                        //throw new InvalidOperationException($"Module variant events from module {palletModule.Name} are null");
                    }

                    foreach (var moduleEvent in moduleEvents.Variants)
                    {
                        var callDto = new ModuleEventsDto()
                        {
                            Name = moduleEvent.Name,
                            Documentation = _modelBuilder.BuildDocumentation(moduleEvent.Docs),
                            Lookup = moduleEvent.Index,
                            Arguments = moduleEvent.TypeFields != null ? moduleEvent.TypeFields.Select(tf => _currentMetaData.BuildTypeField(tf)).ToList() : null
                        };

                        moduleEventsDto.Add(callDto);
                    }
                }
                else
                    throw new InvalidCastException($"Module calls from module {palletModule.Name} cannot be casted to NodeTypeVariant");
            }

            return moduleEventsDto;
        }
        #endregion

        #region Constants
        public List<ModuleConstantsDto> GetModuleConstants(string palletName)
                => GetModuleConstants(_currentMetaData.GetPalletModule(palletName));

        public List<ModuleConstantsDto> GetModuleConstants(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleConstantsDto = new List<ModuleConstantsDto>();
            if (palletModule.Constants != null)
            {
                foreach(var constant in palletModule.Constants)
                {
                    //var testType = _currentMetaData.GetPalletType(constant.TypeId);

                    var moduleConstant = new ModuleConstantsDto()
                    {
                        Name = constant.Name,
                        Type = _currentMetaData.WriteType(constant.TypeId),
                        Documentation = _modelBuilder.BuildDocumentation(constant.Docs),
                        Value = Utils.Bytes2HexString(constant.Value)
                    };

                    // TODO: add a mapping with NodePrimitive ?
                    //var mapping = new EventMapping();
                    //mapping.Search()
                    moduleConstantsDto.Add(moduleConstant);
                }
            }

            return moduleConstantsDto;
        }
        #endregion

        #region Storage
        public List<ModuleStorageDto> GetModuleStorage(string palletName)
                => GetModuleStorage(_currentMetaData.GetPalletModule(palletName));

        public List<ModuleStorageDto> GetModuleStorage(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var modulesDto = new List<ModuleStorageDto>();
            if (palletModule.Storage != null && palletModule.Storage.Entries != null)
            {
                foreach(var entry in palletModule.Storage.Entries)
                {
                    var storage = new ModuleStorageDto()
                    {
                        Name = entry.Name,
                        Documentation = _modelBuilder.BuildDocumentation(entry.Docs),
                        StorageModifier = entry.Modifier switch
                        {
                            Storage.Modifier.Default => StorageModifier.Default,
                            Storage.Modifier.Optional => StorageModifier.Optional,
                        },
                        Default = Utils.Bytes2HexString(entry.Default),
                        StorageType = entry.StorageType switch
                        {
                            Storage.Type.Map => StorageType.Map,
                            Storage.Type.Plain => StorageType.Plain,
                            Storage.Type.NMap => StorageType.NMap,
                            Storage.Type.DoubleMap => StorageType.DoubleMap,
                        }
                    };
                    modulesDto.Add(storage);
                }

            }

            return modulesDto;
        }
        #endregion

        #region Errors
        public List<ModuleErrorsDto> GetModuleErrors(string palletName)
                => GetModuleErrors(_currentMetaData.GetPalletModule(palletName));

        public List<ModuleErrorsDto> GetModuleErrors(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var modulesDto = new List<ModuleErrorsDto>();
            if (palletModule.Errors != null)
            {
                var nodeType = _currentMetaData.GetPalletType(palletModule.Errors.TypeId);

                if (nodeType is NodeTypeVariant nodeTypeVariant)
                {
                    if (nodeTypeVariant.Variants == null)
                    {
                        // TODO : warning log -> weird behavior
                        return modulesDto;
                        //throw new InvalidOperationException($"Module variant errors from module {palletModule.Name} are null");
                    }

                    foreach (var typeVariant in nodeTypeVariant.Variants)
                    {
                        modulesDto.Add(new ModuleErrorsDto()
                        {
                            Name = typeVariant.Name,
                            Documentation = _modelBuilder.BuildDocumentation(typeVariant.Docs),
                        });
                    }
                }
                else
                    throw new InvalidCastException($"Module calls from module {palletModule.Name} cannot be casted to NodeTypeVariant");
            }

            return modulesDto;
        }
        #endregion

        #region Details
        public ModuleDetailDto GetModuleDetail(string palletName)
            => GetModuleDetail(_currentMetaData.GetPalletModule(palletName));

        public ModuleDetailDto GetModuleDetail(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleDetail = new ModuleDetailDto()
            {
                Information = new ModuleInfoDto()
                {
                    PalletName = palletModule.Name,
                    Documentation = string.Empty,
                }
            };

            moduleDetail.Calls = GetModuleCalls(palletModule);
            moduleDetail.Events = GetModuleEvents(palletModule);
            moduleDetail.Constants = GetModuleConstants(palletModule);
            moduleDetail.Storage = GetModuleStorage(palletModule);
            moduleDetail.Errors = GetModuleErrors(palletModule);


            return moduleDetail;
        }
        #endregion

        public Task<int> GetNbCallAsync(string moduleId, DateTime from, DateTime to, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RuntimeVersionDto>> GetRuntimeVersionsAsync(CancellationToken cancellationToken)
        {
            var runtimeVersionsDto = new List<RuntimeVersionDto>();

            var runtimeVersionDto = new RuntimeVersionDto()
            {
                ImplName = _substrateService.RuntimeVersion.ImplName,
                SpecName = _substrateService.RuntimeVersion.SpecName,
                AuthoringVersion = _substrateService.RuntimeVersion.AuthoringVersion,
                ImplVersion = _substrateService.RuntimeVersion.ImplVersion,
                TransactionVersion = _substrateService.RuntimeVersion.TransactionVersion,
                SpecVersion = _substrateService.RuntimeVersion.SpecVersion
            };

            runtimeVersionsDto.Add(runtimeVersionDto);
            return runtimeVersionsDto;
        }
    }
}