﻿using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Polkanalysis.Domain.Helper.Enumerables;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Substrate.NET.Metadata;
using Substrate.NET.Metadata.Service;
using MediatR;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Substrate.NET.Metadata.Base;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Runtime.PalletVersion;

namespace Polkanalysis.Domain.UseCase.Runtime.SpecVersion
{
    /// <summary>
    /// Get all Substrate runtime version
    /// </summary>
    public class SpecVersionHandler : Handler<SpecVersionHandler, IEnumerable<SpecVersionDto>, SpecVersionsQuery>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateService _substrateService;

        public SpecVersionHandler(
            SubstrateDbContext dbContext,
            ISubstrateService substrateService,
            ILogger<SpecVersionHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<IEnumerable<SpecVersionDto>, ErrorResult>> HandleInnerAsync(SpecVersionsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<SpecVersionModel> dbRes = _dbContext.SpecVersionModels;

            if (!string.IsNullOrEmpty(request.BlockchainName))
            {
                dbRes = dbRes.Where(x => x.BlockchainName == request.BlockchainName);
            }

            if (request.SpecVersionNumber is not null)
            {
                dbRes = dbRes.Where(x => x.SpecVersion == request.SpecVersionNumber);
            }

            var specVersionExtended = await dbRes
                .ExtendWith(x => _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(x.BlockStart), cancellationToken))
                .WaitAllAndGetResultAsync();

            return specVersionExtended.Select(x => new SpecVersionDto()
            {
                SpecVersion = x.Item1.SpecVersion,
                BlockStart = x.Item1.BlockStart,
                BlockStartHash = x.Item2.Value,
                BlockEnd = x.Item1.BlockEnd,
                BlockEndHash = "",
                MetadataVersion = x.Item1.MetadataVersion
            }).ToList();

        }
    }

    /// <summary>
    /// Insert a new Substrate version in database
    /// </summary>
    public class SpecVersionCommandHandler : Handler<SpecVersionCommandHandler, bool, SpecVersionCommand>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ICoreService _coreService;
        private readonly ISubstrateService _substrateService;

        public SpecVersionCommandHandler(
            SubstrateDbContext dbContext,
            ISubstrateService substrateService,
            ILogger<SpecVersionCommandHandler> logger,
            IDistributedCache cache,
            ICoreService coreService) : base(logger, cache)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
            _coreService = coreService;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SpecVersionCommand request, CancellationToken cancellationToken)
        {
            var metadataTarget = await _substrateService.Rpc.State.GetMetaDataAsync(request.BlockHash.Bytes, cancellationToken);

            if (string.IsNullOrEmpty(metadataTarget))
                throw new InvalidOperationException($"Metadata from block {request.BlockStart} is empty...");

            // Is it already inserted ?
            if(_dbContext.SpecVersionModels.Any(x => (x.BlockchainName == _substrateService.BlockchainName) && (x.SpecVersion == request.SpecVersion)))
            {
                _logger.LogInformation("SpecVersion = {version} for blockchain {blockchainName} already exists in database !", request.SpecVersion, _substrateService.BlockchainName);
                return true;
            }

            var date = await _coreService.GetDateTimeFromTimestampAsync(request.BlockStart, cancellationToken);

            var metadataInfo = new CheckRuntimeMetadata(metadataTarget);
            
            var model = new SpecVersionModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                SpecVersion = request.SpecVersion,
                BlockStart = request.BlockStart,
                BlockStartDateTime = date,
                BlockEnd = null,
                BlockEndDateTime = null,
                MetadataVersion = metadataInfo.MetaDataInfo.Version.Value,
                Metadata = metadataTarget,
            };
            await _dbContext.AddAsync(model, cancellationToken);

            // Update the last version if exist
            bool hasPreviousVersion = _dbContext.SpecVersionModels.Any(x => (x.BlockchainName == _substrateService.BlockchainName) && (x.BlockEnd == null));
            if (hasPreviousVersion)
            {
                var lastVersion = _dbContext.SpecVersionModels.Where(x => (x.BlockchainName == _substrateService.BlockchainName) && (x.BlockEnd == null)).Single();
                lastVersion.BlockEnd = request.BlockStart - 1;
                lastVersion.BlockEndDateTime = await _coreService.GetDateTimeFromTimestampAsync(request.BlockStart - 1, cancellationToken);
            }

            var nbRows = await _dbContext.SaveChangesAsync(cancellationToken);
            var nbRowsExpected = 1 + (hasPreviousVersion ? 1 : 0);
            if (nbRows != nbRowsExpected)
                _logger.LogWarning("[{handler}] Inserted rows are inconsistent. Expected {expectedResult} but was {result}", nameof(SpecVersionHandler), nbRowsExpected, nbRows);

            return true;
        }

        /// <summary>
        /// Check pallets which changed when a new spec version is release and increment their version in database
        /// </summary>
        /// <returns></returns>
        //public async Task OnUpgradeVersionCheckPalletChangedAsync(uint blockStart,
        //    string metadataSource, string metadataTarget, MetadataVersion version, CancellationToken cancellationToken)
        //{
        //    IMetadataDiffBase<IMetadataDifferentialModules> res = version switch
        //    {
        //        MetadataVersion.V9 => _metadataService.MetadataCompareV9(new MetadataV9(metadataSource), new MetadataV9(metadataTarget)),
        //        MetadataVersion.V10 => _metadataService.MetadataCompareV10(new MetadataV10(metadataSource), new MetadataV10(metadataTarget)),
        //        MetadataVersion.V11 => _metadataService.MetadataCompareV11(new MetadataV11(metadataSource), new MetadataV11(metadataTarget)),
        //        MetadataVersion.V12 => _metadataService.MetadataCompareV12(new MetadataV12(metadataSource), new MetadataV12(metadataTarget)),
        //        MetadataVersion.V13 => _metadataService.MetadataCompareV13(new MetadataV13(metadataSource), new MetadataV13(metadataTarget)),
        //        MetadataVersion.V14 => _metadataService.MetadataCompareV14(new MetadataV14(metadataSource), new MetadataV14(metadataTarget)),
        //        _ => throw new InvalidOperationException($"MetadataV{version} comparison is not yet supported ! Stay tuned.")
        //    };

        //    if (res.ChangedModules.Count() == 0)
        //        _logger.LogWarning("No modules has changed, please check...");

        //    // First let's insert new modules
        //    foreach (var moduleName in res.ChangedModules.Select(x => x.ModuleName))
        //    {
        //        await _dbContext.AddAsync(new PalletVersionModel()
        //        {
        //            BlockchainName = _substrateService.BlockchainName,
        //            PalletName = moduleName,
        //            PalletVersion = 1,
        //            BlockStart = blockStart,
        //            BlockEnd = null,
        //        }, cancellationToken);
        //    }

        //    foreach (var moduleName in res.ChangedModules.Select(x => x.ModuleName))
        //    {
        //        var palletDb = _dbContext.PalletVersionModels.Where(x => x.PalletName.ToLowerInvariant() == moduleName.ToLowerInvariant());

        //        if (!palletDb.Any())
        //            _logger.LogWarning($"{moduleName} has changed but is not present in the database");

        //        var lastVersion = palletDb.OrderBy(x => x.BlockStart).Last();
        //        lastVersion.BlockEnd = blockStart - 1;

        //        await _dbContext.AddAsync(new PalletVersionModel()
        //        {
        //            BlockchainName = _substrateService.BlockchainName,
        //            PalletName = moduleName,
        //            PalletVersion = lastVersion.PalletVersion + 1,
        //            BlockStart = blockStart,
        //            BlockEnd = null,
        //        }, cancellationToken);
        //    }

        //    foreach (var moduleName in res.RemovedModules.Select(x => x.ModuleName))
        //    {
        //        var palletDb = _dbContext.PalletVersionModels.Where(x => x.PalletName.ToLowerInvariant() == moduleName.ToLowerInvariant());

        //        if (!palletDb.Any())
        //            _logger.LogWarning($"{moduleName} has changed but is not present in the database");
        //        await _dbContext.AddAsync(new PalletVersionModel()
        //        {
        //            BlockchainName = _substrateService.BlockchainName,
        //            PalletName = moduleName,
        //            PalletVersion = 1,
        //            BlockStart = blockStart,
        //            BlockEnd = null,
        //        }, cancellationToken);
        //    }

        //    var nbRows = _dbContext.SaveChanges();
        //    if (nbRows != 1)
        //        throw new InvalidOperationException("Inserted rows are inconsistent");

        //}
    }
}
