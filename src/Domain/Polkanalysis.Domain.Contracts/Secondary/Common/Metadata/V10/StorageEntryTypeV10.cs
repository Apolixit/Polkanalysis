using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10
{
    public class StorageEntryTypeMapV10 : StorageEntryTypeMap<StorageType.HasherV10>
    {
    }

    public class StorageEntryTypeDoubleMapV10 : StorageEntryTypeDoubleMap<StorageType.HasherV10>
    {
    }
}