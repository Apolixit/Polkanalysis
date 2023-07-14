using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Repository.Version
{
    //public class VersionDatabaseRepository : IVersionDatabaseRepository
    //{
    //    protected readonly SubstrateDbContext _context;
    //    private readonly ISubstrateService _substrateService;
    //    protected readonly ILogger<VersionDatabaseRepository> _logger;

    //    public VersionDatabaseRepository(SubstrateDbContext context, ISubstrateService substrateService, ILogger<VersionDatabaseRepository> logger)
    //    {
    //        _context = context;
    //        _substrateService = substrateService;
    //        _logger = logger;
    //    }

    //    public async Task InsertNewSpecVersionAsync(U32 specVersion, uint blockStart, uint? blockEnd, CancellationToken cancellationToken)
    //    {
    //        var startBlockHash = await _substrateService.Storage.System.BlockHashAsync(new U32(blockStart), cancellationToken);
    //        var metadata = await _substrateService.Rpc.State.GetMetaDataAtAsync(startBlockHash.Value, cancellationToken);

    //        var model = new SpecVersionModel()
    //        {
    //            BlockchainName = _substrateService.BlockchainName,
    //            SpecVersion = specVersion.Value,
    //            BlockStart = blockStart,
    //            BlockEnd = blockEnd,
    //            Metadata = metadata ?? string.Empty,
    //        };

    //        await _context.AddAsync(model, cancellationToken);
    //        var nbRows = _context.SaveChanges();
    //        if (nbRows != 1)
    //            throw new InvalidOperationException("Inserted rows are inconsistent");
    //    }

    //    public async Task InsertNewPalletVersionAsync(uint palletId, int palletVersion, uint blockStart, uint? blockEnd, CancellationToken cancellationToken)
    //    {
    //        var model = new PalletVersionModel()
    //        {
    //            BlockchainName = _substrateService.BlockchainName,
    //            PalletId = (int)palletId,
    //            PalletName = _substrateService.RuntimeMetadata.NodeMetadata.Modules.SingleOrDefault(x => x.Value.Index == palletId).Value.Name,
    //            PalletVersion = palletVersion,
    //            BlockStart = blockStart,
    //            BlockEnd = blockEnd,
    //        };

    //        await _context.AddAsync(model, cancellationToken);
    //        var nbRows = _context.SaveChanges();
    //        if (nbRows != 1)
    //            throw new InvalidOperationException("Inserted rows are inconsistent");
    //    }

    //    public async Task<IEnumerable<SpecVersions>> GetAllSpecVersionAsync(CancellationToken cancellationToken)
    //    {
    //        return await _context.BlockchainVersionModels.ToListAsync(cancellationToken);
    //    }

    //    public async Task<SpecVersions?> GetSpecVersionAtBlockAsync(uint blockNumber, CancellationToken cancellationToken)
    //    {
    //        return await _context.BlockchainVersionModels
    //            .SingleOrDefaultAsync(b => b.BlockStart <= blockNumber && (b.BlockEnd == null || b.BlockEnd <= blockNumber), cancellationToken);
    //    }

    //    public async Task<IEnumerable<PalletVersions>> GetAllPalletVersionAsync(CancellationToken cancellationToken)
    //    {
    //        return await _context.PalletVersionModels.ToListAsync(cancellationToken);
    //    }

    //    public async Task<IEnumerable<PalletVersions>> GetPalletVersionForPalletNameAsync(string palletName, CancellationToken cancellationToken)
    //    {
    //        return await _context.PalletVersionModels.Where(p => p.PalletName == palletName).ToListAsync(cancellationToken);
    //    }

    //    public async Task<PalletVersionModel?> GetPalletVersionForPalletNameAtBlockAsync(string palletName, uint blockNumber, CancellationToken cancellationToken)
    //    {
    //        return await _context.PalletVersionModels
    //            .SingleOrDefaultAsync(p => p.PalletName == palletName && p.BlockStart >= blockNumber &&
    //            (p.BlockEnd == null || p.BlockEnd <= blockNumber), cancellationToken);
    //    }
    //}
}
