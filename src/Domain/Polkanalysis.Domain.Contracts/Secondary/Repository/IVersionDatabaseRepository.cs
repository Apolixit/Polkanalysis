using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IVersionDatabaseRepository
    {
        Task<IEnumerable<PalletVersions>> GetAllPalletVersionAsync(CancellationToken cancellationToken);
        Task<IEnumerable<SpecVersions>> GetAllSpecVersionAsync(CancellationToken cancellationToken);
        Task<IEnumerable<SpecVersions>> GetPalletVersionForPalletNameAsync(string palletName, CancellationToken cancellationToken);
        Task<PalletVersions?> GetPalletVersionForPalletNameAtBlockAsync(string palletName, uint blockNumber, CancellationToken cancellationToken);
        Task<PalletVersions?> GetSpecVersionAtBlockAsync(uint blockNumber, CancellationToken cancellationToken);
        Task InsertNewPalletVersionAsync(uint palletId, int palletVersion, uint blockStart, uint? blockEnd, CancellationToken cancellationToken);
        Task InsertNewSpecVersionAsync(U32 specVersion, uint blockStart, uint? blockEnd, CancellationToken cancellationToken);
    }
}