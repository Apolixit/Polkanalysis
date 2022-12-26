using Ajuna.NetApi.Model.Meta;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Runtime
{
    public class CurrentMetaData : ICurrentMetaData
    {
        public readonly ISubstrateNodeRepository _substrateNodeRepository;

        public CurrentMetaData(ISubstrateNodeRepository substrateNodeRepository)
        {
            this._substrateNodeRepository = substrateNodeRepository;
        }

        public PalletModule GetPalletModule(string palletName)
        {
            return _substrateNodeRepository.Client.MetaData.NodeMetadata.Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;
        }
    }
}
