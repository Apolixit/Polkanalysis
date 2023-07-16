using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class StorageEntryTypeMapV11 : StorageEntryTypeMap<StorageType.Hasher>
    {
    }

    public class StorageEntryTypeDoubleMapV11 : StorageEntryTypeDoubleMap<StorageType.Hasher>
    {
    }
}