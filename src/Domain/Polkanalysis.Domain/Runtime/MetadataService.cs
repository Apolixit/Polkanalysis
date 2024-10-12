using Substrate.NetApi.Model.Meta;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata;
using Substrate.NET.Metadata.V14;
using Polkanalysis.Domain.Contracts.Service;
using Substrate.NET.Metadata.Base;
using System;
using Substrate.NET.Metadata.Service;
using System.Threading;
using Polkanalysis.Infrastructure.Database;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Substrate.NetApi;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;

namespace Polkanalysis.Domain.Runtime
{
    public class MetadataService : IMetadataService
    {
        public readonly ISubstrateService _substrateService;
        public readonly ICoreService _coreService;
        public readonly SubstrateDbContext _db;
        private readonly ILogger<MetadataService> _logger;

        public MetadataService(ISubstrateService substrateService, SubstrateDbContext db, ICoreService coreService, ILogger<MetadataService> logger)
        {
            _substrateService = substrateService;
            _db = db;
            _coreService = coreService;
            _logger = logger;
        }

        private MetaData? _metadata;
        public MetaData MetaData
        {
            get
            {
                if (_metadata == null)
                {
                    _metadata = _substrateService.GetMetadataAsync(CancellationToken.None).Result;
                }
                return _metadata;
            }
        }

        public void SetMetadata(MetaData metaData)
        {
            _metadata = metaData;
        }

        public uint NodeVersion => _substrateService.RuntimeVersion.SpecVersion;


        #region Write Type
        public string WriteType(uint typeId)
        {
            var detailType = GetPalletType(typeId);

            if (detailType is NodeTypeVariant detailVariant)
                return WriteNodeVariant(detailVariant);
            else if (detailType is NodeTypeCompact detailCompact)
                return WriteNodeCompact(detailCompact);
            else if (detailType is NodeTypePrimitive detailPrimitive)
                return WriteNodePrimitive(detailPrimitive);
            else if (detailType is NodeTypeComposite detailComposite)
                return WriteNodeComposite(detailComposite);
            else if (detailType is NodeTypeSequence detailSequence)
                return WriteNodeSequence(detailSequence);
            else if (detailType is NodeTypeTuple detailTuple)
                return WriteNodeTuple(detailTuple);
            else if (detailType is NodeTypeArray detailArray)
                return WriteNodeArray(detailArray);
            else
                throw new NotSupportedException("Type not supported yet..."); // BitSequence ??
        }

        public string WriteNodeVariant(NodeTypeVariant nodeType)
        {
            string display = string.Join(":", nodeType.Path);
            if (nodeType.TypeParams != null && nodeType.TypeParams.Length > 0)
            {
                display = $"{display}<{string.Join(",", nodeType.TypeParams.Where(p => p.TypeId != null).Select(p => WriteType((uint)p.TypeId)))}>";
            }

            return display;
        }

        public string WriteNodeCompact(NodeTypeCompact nodeType)
        {
            return $"{nodeType.TypeDef}<{WriteType(nodeType.TypeId)}>";
        }

        public string WriteNodePrimitive(NodeTypePrimitive nodeType)
        {
            return nodeType.Primitive.ToString();
        }

        public string WriteNodeComposite(NodeTypeComposite nodeType)
        {
            var display = string.Join(":", nodeType.Path);
            if (nodeType.TypeParams != null && nodeType.TypeParams.Length > 0)
            {
                display = $"{display}<{string.Join(",", nodeType.TypeParams.Select(x => x.Name))}>";
            }
            return display;
        }

        public string WriteNodeSequence(NodeTypeSequence nodeType)
        {
            return $"Vec<{WriteType(nodeType.TypeId)}>";
        }

        public string WriteNodeTuple(NodeTypeTuple nodeType)
        {
            return $"({string.Join(",", nodeType.TypeIds.Select(WriteType))})";
        }

        public string WriteNodeArray(NodeTypeArray nodeType)
        {
            return $"{WriteType(nodeType.TypeId)}[{nodeType.Length}]";
        }
        #endregion

        public TypeFieldDto BuildTypeField(NodeTypeField node)
        {
            var dto = new TypeFieldDto() { 
                Name = node.Name,
                Type = WriteType(node.TypeId),
                TypeName = node.TypeName,
            };
            
            return dto;
        }

        /// <summary>
        /// Fetch the metadata from the node and return it as a Metadata object
        /// </summary>
        /// <param name="specVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MetadataDto?> GetMetadataAsync(uint specVersion, CancellationToken cancellationToken)
        {
            // Fetch the metadata version from the database
            var specVersionDb = _db.SpecVersionModels.SingleOrDefault(x => x.SpecVersion == specVersion);

            if (specVersionDb is null)
            {
                _logger.LogError("Unable to find metadata for spec version {specVersion} in the database", specVersion);
                return null;
            }

            return buildMetadataDtoFromDb(specVersionDb);
        }

        /// <summary>
        /// Build the DTO from Database instance
        /// </summary>
        /// <param name="specVersionDb"></param>
        /// <returns></returns>
        private MetadataDto buildMetadataDtoFromDb(SpecVersionModel specVersionDb)
        {
            string metadataHex = specVersionDb.Metadata;

            // Get the metadata from the node with his block number
            var metadata = _substrateService.GetMetadataFromHex(metadataHex);
            var nextSpecVersion = _db.SpecVersionModels.SingleOrDefault(x => x.BlockStart == specVersionDb.BlockEnd + 1);

            var dateStartSpecVersion = specVersionDb.BlockStartDateTime;

            DateTime? dateStartNextSpecVersion = specVersionDb.BlockEndDateTime;

            return new MetadataDto()
            {
                Origin = metadata.Origin,
                Magic = metadata.Magic,
                Hex = metadataHex,
                SpecVersion = specVersionDb.SpecVersion,
                Duration = (dateStartNextSpecVersion ?? DateTime.UtcNow) - dateStartSpecVersion,
                MajorVersion = MetadataUtils.GetMetadataVersion(metadataHex),
                NbPallets = metadata.NodeMetadata.Modules.Count,
            };
        }

        /// <summary>
        /// Return all the metadata from the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<MetadataDto>> GetAllMetadataInfoAsync(CancellationToken cancellationToken)
        {
            var result = new List<MetadataDto>();

            foreach(var specVersionDb in _db.SpecVersionModels)
            {
                result.Add(buildMetadataDtoFromDb(specVersionDb));
            }

            return result;
        }

        public NodeType GetPalletType(uint typeId)
        {
            NodeType? nodeType = null;
            MetaData.NodeMetadata.Types.TryGetValue(typeId, out nodeType);

            if (nodeType == null)
            {
                _logger.LogError($"{nameof(nodeType)} is not found in current metadata type");
                throw new KeyNotFoundException($"{nameof(nodeType)} is not found in current metadata type");
            }

            return (NodeType)nodeType;
        }

        /// <summary>
        /// Get module from his index from current metadata
        /// </summary>
        /// <param name="moduleIndex"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PalletModule> GetPalletModuleByIndexAsync(byte moduleIndex, CancellationToken cancellationToken)
        {
            return GetPalletModuleByIndex(MetaData, moduleIndex);
        }

        /// <summary>
        /// Get mod from his index from given metadata
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="moduleIndex"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        private PalletModule GetPalletModuleByIndex(MetaData metadata, byte moduleIndex)
        {
            var pallet = metadata.NodeMetadata.Modules[moduleIndex];

            if (pallet == null)
            {
                _logger.LogError($"Pallet with index {moduleIndex} not found in metadata");
                throw new KeyNotFoundException($"Pallet with index {moduleIndex} not found in metadata");
            }

            return pallet;
        }

        /// <summary>
        /// Get module by this name from current metadata
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PalletModule> GetPalletModuleByNameAsync(string palletName, CancellationToken cancellationToken)
        {
            return GetPalletModuleByNameInternal(MetaData, palletName);
        }

        /// <summary>
        /// Get module by this name from given metadata
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="palletName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private PalletModule GetPalletModuleByNameInternal(MetaData metadata, string palletName)
        {
            var pallet = metadata.NodeMetadata.Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;
            if (pallet == null)
            {
                _logger.LogError($"{palletName} does not exists in current metadata");
                throw new InvalidOperationException($"{nameof(palletName)}");
            }

            return pallet;
        }

        #region Calls
        public async Task<List<ModuleCallsDto>> GetModuleCallsAsync(string palletName, CancellationToken cancellationToken)
            => GetModuleCallsInternal(GetPalletModuleByNameInternal(MetaData, palletName));

        public List<ModuleCallsDto> GetModuleCallsInternal(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleCallsDto = new List<ModuleCallsDto>();
            if (palletModule.Calls != null)
            {
                var nodeTypeCalls = GetPalletType(palletModule.Calls.TypeId);

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
                            Documentation = ModelBuilder.BuildDocumentation(moduleCall.Docs),
                            Lookup = moduleCall.Index,
                            NbParameter = moduleCall.TypeFields != null ? moduleCall.TypeFields.Length : 0,
                            Arguments = moduleCall.TypeFields != null ? moduleCall.TypeFields.Select(BuildTypeField).ToList() : null,
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
        public async Task<List<ModuleEventsDto>> GetModuleEventsAsync(string palletName, CancellationToken cancellationToken)
                => GetModuleEventsInternal(GetPalletModuleByNameInternal(MetaData, palletName));

        private List<ModuleEventsDto> GetModuleEventsInternal(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleEventsDto = new List<ModuleEventsDto>();
            if (palletModule.Events != null)
            {
                var nodeTypeEvent = GetPalletType(palletModule.Events.TypeId);

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
                            Documentation = ModelBuilder.BuildDocumentation(moduleEvent.Docs),
                            Lookup = moduleEvent.Index,
                            Arguments = moduleEvent.TypeFields != null ? moduleEvent.TypeFields.Select(tf => BuildTypeField(tf)).ToList() : null
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
        public async Task<List<ModuleConstantsDto>> GetModuleConstantsAsync(string palletName, CancellationToken cancellationToken)
                => GetModuleConstantsInternal(GetPalletModuleByNameInternal(MetaData, palletName));

        public List<ModuleConstantsDto> GetModuleConstantsInternal(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var moduleConstantsDto = new List<ModuleConstantsDto>();
            if (palletModule.Constants != null)
            {
                foreach (var constant in palletModule.Constants)
                {
                    //var testType = _currentMetaData.GetPalletType(constant.TypeId);

                    var moduleConstant = new ModuleConstantsDto()
                    {
                        Name = constant.Name,
                        Type = WriteType(constant.TypeId),
                        Documentation = ModelBuilder.BuildDocumentation(constant.Docs),
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
        public async Task<List<ModuleStorageDto>> GetModuleStorageAsync(string palletName, CancellationToken cancellationToken)
                => GetModuleStorageInternal(GetPalletModuleByNameInternal(MetaData, palletName));

        public List<ModuleStorageDto> GetModuleStorageInternal(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var modulesDto = new List<ModuleStorageDto>();
            if (palletModule.Storage != null && palletModule.Storage.Entries != null)
            {
                foreach (var entry in palletModule.Storage.Entries)
                {
                    var storage = new ModuleStorageDto()
                    {
                        Name = entry.Name,
                        Documentation = ModelBuilder.BuildDocumentation(entry.Docs),
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
        public async Task<List<ModuleErrorsDto>> GetModuleErrorsAsync(string palletName, CancellationToken cancellationToken)
                => GetModuleErrorsInternal(GetPalletModuleByNameInternal(MetaData, palletName));

        public List<ModuleErrorsDto> GetModuleErrorsInternal(PalletModule palletModule)
        {
            if (palletModule == null)
                throw new ArgumentNullException($"{palletModule}");

            var modulesDto = new List<ModuleErrorsDto>();
            if (palletModule.Errors != null)
            {
                var nodeType = GetPalletType(palletModule.Errors.TypeId);

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
                            Documentation = ModelBuilder.BuildDocumentation(typeVariant.Docs),
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
        public async Task<ModuleDetailDto> GetModuleDetailAsync(string palletName, CancellationToken cancellationToken)
            => GetModuleDetailInternal(GetPalletModuleByNameInternal(MetaData, palletName));

        private ModuleDetailDto GetModuleDetailInternal(PalletModule palletModule)
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

            moduleDetail.Calls = GetModuleCallsInternal(palletModule);
            moduleDetail.Events = GetModuleEventsInternal(palletModule);
            moduleDetail.Constants = GetModuleConstantsInternal(palletModule);
            moduleDetail.Storage = GetModuleStorageInternal(palletModule);
            moduleDetail.Errors = GetModuleErrorsInternal(palletModule);


            return moduleDetail;
        }
        #endregion

        public Task<int> GetNbCallAsync(string moduleName, DateTime from, DateTime to, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SpecVersionDto>> GetRuntimeVersionsAsync(CancellationToken cancellationToken)
        {
            var runtimeVersionsDto = new List<SpecVersionDto>();

            var runtimeVersionDto = new SpecVersionDto()
            {
                SpecVersion = _substrateService.RuntimeVersion.SpecVersion
            };

            runtimeVersionsDto.Add(runtimeVersionDto);
            return runtimeVersionsDto;
        }
    }
}
