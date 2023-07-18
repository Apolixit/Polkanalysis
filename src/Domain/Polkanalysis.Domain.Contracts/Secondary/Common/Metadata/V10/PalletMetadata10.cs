using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10
{
    public class PalletCallMetadataV10 : PalletCallMetadataV9
    {
    }

    public class PalletConstantMetadataV10 : PalletConstantMetadataV9
    {
    }

    public class PalletErrorMetadataV10 : PalletErrorMetadataV9
    {
    }

    public class PalletEventMetadataV10 : PalletEventMetadataV9
    {
    }

    public class StorageEntryTypeMapV10 : StorageEntryTypeMap<StorageType.HasherV10>
    {
    }

    public class StorageEntryTypeDoubleMapV10 : StorageEntryTypeDoubleMap<StorageType.HasherV10>
    {
    }
}
