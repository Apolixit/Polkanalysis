using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11
{
    public class PalletCallMetadataV11 : PalletCallMetadataV10
    {
    }

    public class PalletConstantMetadataV11 : PalletConstantMetadataV10
    {
    }

    public class PalletErrorMetadataV11 : PalletErrorMetadataV10
    {
    }

    public class PalletEventMetadataV11 : PalletEventMetadataV10
    {
    }

    public class StorageEntryTypeMapV11 : StorageEntryTypeMap<StorageType.Hasher>
    {
    }

    public class StorageEntryTypeDoubleMapV11 : StorageEntryTypeDoubleMap<StorageType.Hasher>
    {
    }
}
