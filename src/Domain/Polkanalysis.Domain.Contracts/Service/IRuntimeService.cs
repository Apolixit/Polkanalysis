using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Base;
using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IMetadataService
    {
        Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, int specVersion1, int specVersion2);
        Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, string hexMetadata1, string hexMetadata2);
        MetadataVersion EnsureMetadataVersion(string hexMetadata1, string hexMetadata2);
    }
}