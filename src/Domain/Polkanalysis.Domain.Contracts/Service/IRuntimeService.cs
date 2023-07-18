using Polkanalysis.Domain.Contracts.Secondary.Common.Metadata.Compare;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IMetadataService
    {
        Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, int specVersion1, int specVersion2);
        Task<bool> HasPalletChangedVersionBetweenAsync(string palletName, string hexMetadata1, string hexMetadata2);
        //Task<MetadataDiffV9> MetadataCompareV9Async(string hexMetadata1, string hexMetadata2);
    }
}