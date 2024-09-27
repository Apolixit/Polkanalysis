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

namespace Polkanalysis.Domain.Runtime
{
    public class MetadataService : IMetadataService
    {
        public readonly ISubstrateService _substrateService;
        public readonly IExplorerService _explorerService;
        public readonly SubstrateDbContext _db;
        private readonly ILogger<MetadataService> _logger;

        public MetadataService(ISubstrateService substrateService, SubstrateDbContext db, IExplorerService explorerService, ILogger<MetadataService> logger)
        {
            _substrateService = substrateService;
            _db = db;
            _explorerService = explorerService;
            _logger = logger;
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

            if(specVersionDb is null)
            {
                _logger.LogError("Unable to find metadata for spec version {specVersion} in the database", specVersion);
            }

            var blockStartHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(specVersionDb!.BlockStart), cancellationToken);
            var metadataHex = await _substrateService.Rpc.State.GetMetaDataAsync(blockStartHash, cancellationToken);

            // Get the metadata from the node with his block number
            var metadata = await _substrateService.At(blockStartHash).GetMetadataAsync(cancellationToken);

            var nextSpecVersion = _db.SpecVersionModels.SingleOrDefault(x => x.BlockStart == specVersionDb.BlockEnd + 1);
            
            var dateStartSpecVersion = await _explorerService.GetDateTimeFromTimestampAsync(blockStartHash, cancellationToken);

            DateTime? dateStartNextSpecVersion = null;
            if (nextSpecVersion is not null)
            {
                var blockStartNextSpecVersionHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(nextSpecVersion!.BlockStart), cancellationToken);

                dateStartNextSpecVersion = await _explorerService.GetDateTimeFromTimestampAsync(blockStartNextSpecVersionHash, cancellationToken);
            }

            return new MetadataDto()
            {
                Origin = metadata.Origin,
                Magic = metadata.Magic,
                Hex = metadataHex,
                SpecVersion = specVersion,
                Duration = (dateStartNextSpecVersion ?? DateTime.UtcNow) - dateStartSpecVersion,
                MajorVersion = MetadataUtils.GetMetadataVersion(metadataHex),
                NbPallets = metadata.NodeMetadata.Modules.Count,
            };
        }

        public Task<IEnumerable<MetadataDto>> GetAllMetadataInfoAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public NodeType GetPalletType(uint typeId)
        {
            NodeType? nodeType = null;
            _substrateService.GetMetadataAsync(CancellationToken.None).Result.NodeMetadata.Types.TryGetValue(typeId, out nodeType);

            if (nodeType == null)
            {
                _logger.LogError($"{nameof(nodeType)} is not found in current metadata type");
                throw new KeyNotFoundException($"{nameof(nodeType)} is not found in current metadata type");
            }

            return (NodeType)nodeType;
        }

        public Task<MetadataDto> GetMetadataAsync(int specVersion, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<PalletModule> GetPalletModuleByIndexAsync(byte moduleIndex, CancellationToken cancellationToken)
        {
            return await GetPalletModuleByIndexAsync(await _substrateService.Rpc.Chain.GetBlockHashAsync(cancellationToken), moduleIndex, cancellationToken);
        }

        public async Task<PalletModule> GetPalletModuleByIndexAsync(Hash blockHash, byte moduleIndex, CancellationToken cancellationToken)
        {
            var metadata = await _substrateService.At(blockHash).GetMetadataAsync(cancellationToken);
            var pallet = metadata.NodeMetadata.Modules[moduleIndex];

            if (pallet == null)
            {
                _logger.LogError($"Pallet with index {moduleIndex} not found in metadata");
                throw new KeyNotFoundException($"Pallet with index {moduleIndex} not found in metadata");
            }

            return pallet;
        }

        public async Task<PalletModule> GetPalletModuleByNameAsync(string palletName, CancellationToken cancellationToken)
        {
            return await GetPalletModuleByNameAsync(await _substrateService.Rpc.Chain.GetBlockHashAsync(cancellationToken), palletName, cancellationToken);
        }

        public PalletModule GetPalletModuleByName(MetaData metadata, string palletName, CancellationToken cancellationToken)
        {
            var pallet = metadata.NodeMetadata.Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;
            if (pallet == null)
            {
                _logger.LogError($"{palletName} does not exists in current metadata");
                throw new InvalidOperationException($"{nameof(palletName)}");
            }

            return pallet;
        }

        public async Task<PalletModule> GetPalletModuleByNameAsync(Hash blockHash, string palletName, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrEmpty(palletName, nameof(palletName));
            var metadata = await _substrateService.At(blockHash).GetMetadataAsync(cancellationToken);
            
            return GetPalletModuleByName(metadata, palletName, cancellationToken);
        }
    }
}
