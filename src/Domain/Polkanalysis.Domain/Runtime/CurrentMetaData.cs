using Substrate.NetApi.Model.Meta;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata;

namespace Polkanalysis.Domain.Runtime
{
    public class CurrentMetaData : ICurrentMetaData
    {
        public readonly ISubstrateService _substrateNodeRepository;
        private readonly ILogger<CurrentMetaData> _logger;

        public CurrentMetaData(ISubstrateService substrateNodeRepository, ILogger<CurrentMetaData> logger)
        {
            this._substrateNodeRepository = substrateNodeRepository;
            _logger = logger;
        }

        public uint NodeVersion => _substrateNodeRepository.RuntimeVersion.SpecVersion;


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

        public virtual INodeMetadataV14 GetCurrentMetadata()
        {
            return _substrateNodeRepository.RuntimeMetadata.NodeMetadata;
        }

        public async Task<NodeMetadataV14> GetMetadataAsync(Hash blockHash, CancellationToken cancellationToken)
        {
            var metadataString = await _substrateNodeRepository.Rpc.State.GetMetaDataAsync(blockHash, cancellationToken);
            var mdv14 = new RuntimeMetadata();
            mdv14.Create(metadataString);
            var metaData  = new MetaData(mdv14);

            return metaData.NodeMetadata;
        }

        public async Task<PalletModule> GetPalletModuleAsync(Hash blockHash, byte moduleIndex, CancellationToken cancellationToken)
        {
            var metadata = await GetMetadataAsync(blockHash, cancellationToken);
            var pallet = metadata.Modules[moduleIndex];

            if (pallet == null)
            {
                _logger.LogError($"Pallet with index {moduleIndex} not found in metadata");
                throw new KeyNotFoundException($"Pallet with index {moduleIndex} not found in metadata");
            }

            return pallet;
        }

        public PalletModule GetPalletModule(string palletName)
        {
            if (string.IsNullOrEmpty(palletName))
            {
                _logger.LogError($"Param {nameof(palletName)} is not set while requesting pallet information data");
                throw new ArgumentNullException($"{nameof(palletName)}");
            }

            //var pallet = GetCurrentMetadata().Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;
            var pallet = GetMetadataAsync(new Hash("0x3398425fd67309e6eab9a0b11a7c9f554f641a8004fc5c4214407b948515cfd7")).Result.Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;
            if(pallet == null)
            {
                _logger.LogError($"{palletName} does not exists in current metadata");
                throw new InvalidOperationException($"{nameof(palletName)}");
            }

            return pallet;
        }

        public NodeType GetPalletType(uint typeId)
        {
            NodeType? nodeType = null;
            GetCurrentMetadata().Types.TryGetValue(typeId, out nodeType);

            if (nodeType == null)
            {
                _logger.LogError($"{nameof(nodeType)} is not found in current metadata type");
                throw new KeyNotFoundException($"{nameof(nodeType)} is not found in current metadata type");
            }

            return (NodeType)nodeType;
        }
    }
}
