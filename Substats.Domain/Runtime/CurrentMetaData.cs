using Ajuna.NetApi.Model.Meta;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Dto.Module;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;

namespace Substats.Domain.Runtime
{
    public class CurrentMetaData : ICurrentMetaData
    {
        public readonly ISubstrateNodeRepository _substrateNodeRepository;
        private readonly ILogger<CurrentMetaData> _logger;

        public CurrentMetaData(ISubstrateNodeRepository substrateNodeRepository, ILogger<CurrentMetaData> logger)
        {
            this._substrateNodeRepository = substrateNodeRepository;
            _logger = logger;
        }

        public string DisplayTypeDetail(uint typeId)
        {
            var detailType = GetPalletType(typeId);
            string fullType = string.Empty;

            if (detailType is NodeTypeVariant detailVariant)
            {
                fullType = string.Join(":", detailType.Path);
            }
            else if (detailType is NodeTypeCompact detailCompact)
            {
                fullType += $"{detailCompact.TypeDef}<{DisplayTypeDetail(detailCompact.TypeId)}>";
            }
            else if (detailType is NodeTypePrimitive detailPrimitive)
            {
                fullType += detailPrimitive.Primitive;
            }

            return fullType;
        }
        public TypeFieldDto BuildTypeField(NodeTypeField node)
        {
            var detailType = GetPalletType(node.TypeId);

            var dto = new TypeFieldDto() { 
                Name = node.Name,
                Type = DisplayTypeDetail(node.TypeId),
                TypeName = node.TypeName,
            };
            
            return dto;
        }

        public virtual NodeMetadataV14 GetCurrentMetadata()
        {
            return _substrateNodeRepository.Client.MetaData.NodeMetadata;
        }

        public PalletModule GetPalletModule(string palletName)
        {
            if (string.IsNullOrEmpty(palletName))
            {
                //_logger.LogError($"Param {nameof(palletName)} is not set while requesting pallet information data");
                throw new ArgumentNullException($"{nameof(palletName)}");
            }

            var pallet = GetCurrentMetadata().Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;
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
