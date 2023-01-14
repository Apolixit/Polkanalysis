using Ajuna.NetApi.Model.Meta;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Runtime
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
                //_logger.LogError($"{palletName} does not exists in current metadata");
                throw new InvalidOperationException($"{nameof(palletName)}");
            }

            return pallet;
        }

        public NodeType GetPalletType(uint typeId)
        {
            //var nodeType = GetCurrentMetadata().Types[typeId];

            NodeType? nodeType = null;
            GetCurrentMetadata().Types.TryGetValue(typeId, out nodeType);

            if (nodeType == null)
            {
                _logger.LogError($"{nameof(nodeType)} is not found in current metadata type");
                throw new KeyNotFoundException($"{nameof(nodeType)} is not found in current metadata type");
            }

            return nodeType;
        }
    }
}
