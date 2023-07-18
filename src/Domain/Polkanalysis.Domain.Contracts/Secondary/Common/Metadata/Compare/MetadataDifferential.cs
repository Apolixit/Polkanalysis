using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V10;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V11;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V12;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V13;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.V9;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare
{
    public abstract class MetadataDifferential<TStorage, TCall, TEvent, TConstant, TError>
        where TStorage : BaseType, new()
        where TCall : BaseType, new()
        where TEvent : BaseType, new()
        where TConstant : BaseType, new()
        where TError : BaseType, new()
    {
        public IEnumerable<(CompareStatus, TStorage)> Storage { get; set; }
            = Enumerable.Empty<(CompareStatus, TStorage)>();
        public IEnumerable<(CompareStatus, TCall)> Calls { get; set; }
            = Enumerable.Empty<(CompareStatus, TCall)>();
        public IEnumerable<(CompareStatus, TEvent)> Events { get; set; }
            = Enumerable.Empty<(CompareStatus, TEvent)>();
        public IEnumerable<(CompareStatus, TConstant)> Constants { get; set; }
            = Enumerable.Empty<(CompareStatus, TConstant)>();
        public IEnumerable<(CompareStatus, TError)> Errors { get; set; }
            = Enumerable.Empty<(CompareStatus, TError)>();
    }

    public class MetadataDiffV9 : MetadataDifferential<
        PalletStorageMetadataV9, PalletCallMetadataV9, PalletEventMetadataV9, PalletConstantMetadataV9, PalletErrorMetadataV9>
    {
    }

    public class MetadataDiffV10 : MetadataDifferential<
        PalletStorageMetadataV10, PalletCallMetadataV10, PalletEventMetadataV10, PalletConstantMetadataV10, PalletErrorMetadataV10>
    {
    }

    public class MetadataDiffV11 : MetadataDifferential<
        PalletStorageMetadataV11, PalletCallMetadataV11, PalletEventMetadataV11, PalletConstantMetadataV11, PalletErrorMetadataV11>
    {
    }

    public class MetadataDiffV12 : MetadataDifferential<
        PalletStorageMetadataV12, PalletCallMetadataV12, PalletEventMetadataV12, PalletConstantMetadataV12, PalletErrorMetadataV12>
    {
    }

    public class MetadataDiffV13 : MetadataDifferential<
        PalletStorageMetadataV13, PalletCallMetadataV13, PalletEventMetadataV13, PalletConstantMetadataV13, PalletErrorMetadataV13>
    {
    }
}
