using Ajuna.NetApi.Model.Meta;
using Substats.Domain.Contracts.Dto.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Runtime
{
    public interface ICurrentMetaData
    {
        /// <summary>
        /// Return current MetaData
        /// </summary>
        /// <returns></returns>
        public NodeMetadataV14 GetCurrentMetadata();

        /// <summary>
        /// Get current MetaData pallet module from pallet name
        /// </summary>
        /// <param name="palletName"></param>
        /// <returns></returns>
        public PalletModule GetPalletModule(string palletName);

        /// <summary>
        /// Get current MetaData node type from type id
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public NodeType GetPalletType(uint typeId);

        public TypeFieldDto BuildTypeField(NodeTypeField node);

        public string DisplayTypeDetail(uint typeId);
    }
}
