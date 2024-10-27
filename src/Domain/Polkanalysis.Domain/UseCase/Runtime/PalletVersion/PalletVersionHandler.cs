using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary.Repository.Models;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NET.Metadata;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.V9;
using Substrate.NET.Metadata.V10;
using Substrate.NET.Metadata.V11;
using Substrate.NET.Metadata.V12;
using Substrate.NET.Metadata.V13;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Metadata.Compare.Base;
using Substrate.NetApi.Model.Types.Base;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Domain.Helper;
using System.Diagnostics;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Domain.Contracts.Metrics;

namespace Polkanalysis.Domain.UseCase.Runtime.PalletVersion
{
    /// <summary>
    /// Get all pallet version for given pallet
    /// </summary>
    public class PalletVersionHandler : Handler<PalletVersionHandler, IEnumerable<PalletVersionDto>, PalletVersionsQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public PalletVersionHandler(SubstrateDbContext dbContext, ILogger<PalletVersionHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<IEnumerable<PalletVersionDto>, ErrorResult>> HandleInnerAsync(PalletVersionsQuery request, CancellationToken cancellationToken)
        {
            var res = await _dbContext.PalletVersionModels
                .Where(x => x.PalletName == request.PalletName)
                .Select(x => new PalletVersionDto()
                {
                    PalletName = x.PalletName,
                    PalletVersion = x.PalletVersion
                })
                .ToListAsync(cancellationToken);

            return res;
        }
    }

    /// <summary>
    /// Insert a new pallet version for a given pallet in database
    /// </summary>
    public class PalletVersionCommandHandler : Handler<PalletVersionCommandHandler, bool, PalletVersionCommand>
    {
        private readonly SubstrateDbContext _dbContext;
        private readonly ISubstrateService _substrateService;

        public PalletVersionCommandHandler(
            SubstrateDbContext dbContext,
            ISubstrateService substrateService,
            ILogger<PalletVersionCommandHandler> logger,
            IDistributedCache cache) : base(logger, cache)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(PalletVersionCommand request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            // At least we need to have a block number >= 1
            var previousBlockNumber = Math.Max(request.BlockStart - 1, 1);

            try
            {
                var (endPreviousBlockHash, startBlockHash) = await WaiterHelper.WaitAndReturnAsync(
                    _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(previousBlockNumber), cancellationToken),
                    _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(request.BlockStart), cancellationToken)
                );

                // Get metadata hash from previous block and current block
                var (metadataSource, metadataTarget) = await WaiterHelper.WaitAndReturnAsync(
                    _substrateService.Rpc.State.GetMetaDataAsync(endPreviousBlockHash.Bytes, cancellationToken),
                    _substrateService.Rpc.State.GetMetaDataAsync(startBlockHash.Bytes, cancellationToken)
                );

                Guard.Against.NullOrEmpty(metadataSource, nameof(metadataSource));
                Guard.Against.NullOrEmpty(metadataTarget, nameof(metadataTarget));

                // Just ensure previous block was on same Metadata, otherwise we don't do any comparison
                var sourceVersion = MetadataUtils.GetMetadataVersion(metadataSource);
                var targetVersion = MetadataUtils.GetMetadataVersion(metadataTarget);
                //if (sourceVersion != targetVersion)
                //{
                //    var response = $"New metadata major version (from {sourceVersion} to {targetVersion}, we don't do any comparison between major version";
                //    _logger.LogWarning(response);
                //    return UseCaseError(ErrorResult.ErrorType.BusinessError, response);
                //}

                MetadataV14 metadataSourceV14 = convertToV14(metadataSource, sourceVersion);
                MetadataV14 metadataDestinationV14 = convertToV14(metadataTarget, targetVersion);

                IMetadataDiffBase<IMetadataDifferentialModules> res = MetadataUtils.MetadataCompareV14(metadataSourceV14, metadataDestinationV14);

                //IMetadataDiffBase<IMetadataDifferentialModules> res = sourceVersion switch
                //{
                //    MetadataVersion.V9 => MetadataUtils.MetadataCompareV9(new MetadataV9(metadataSource), new MetadataV9(metadataTarget)),
                //    MetadataVersion.V10 => MetadataUtils.MetadataCompareV10(new MetadataV10(metadataSource), new MetadataV10(metadataTarget)),
                //    MetadataVersion.V11 => MetadataUtils.MetadataCompareV11(new MetadataV11(metadataSource), new MetadataV11(metadataTarget)),
                //    MetadataVersion.V12 => MetadataUtils.MetadataCompareV12(new MetadataV12(metadataSource), new MetadataV12(metadataTarget)),
                //    MetadataVersion.V13 => MetadataUtils.MetadataCompareV13(new MetadataV13(metadataSource), new MetadataV13(metadataTarget)),
                //    MetadataVersion.V14 => MetadataUtils.MetadataCompareV14(new MetadataV14(metadataSource), new MetadataV14(metadataTarget)),
                //    _ => throw new InvalidOperationException($"MetadataV{sourceVersion} comparison is not yet supported ! Stay tuned.")
                //};

                _logger.LogDebug("[{handler}] Metadata version {version} comparison ok", nameof(PalletVersionHandler), sourceVersion);

                var addedModules = res.AddedModules.ToList();
                var changedModules = res.ChangedModules.ToList();
                if (!res.ChangedModules.Any())
                {
                    if (request.BlockStart == 1)
                    {
                        addedModules = res.AllModulesDiff.ToList();
                        changedModules.Clear();
                    }
                    else
                        _logger.LogWarning("[{handler}] No modules has changed, please check...", nameof(PalletVersionHandler));
                }


                // First let's insert new modules
                foreach (var moduleName in addedModules.Select(x => x.ModuleName))
                {
                    await _dbContext.AddAsync(new PalletVersionModel()
                    {
                        BlockchainName = _substrateService.BlockchainName,
                        PalletName = moduleName,
                        PalletVersion = 1,
                        BlockStart = request.BlockStart,
                        BlockEnd = null,
                        SpecVersion = request.SpecVersion,
                    }, cancellationToken);
                }

                foreach (var moduleName in changedModules.Select(x => x.ModuleName))
                {
                    var lastVersion = UpdateLastVersionWithBlockEnd(request.BlockStart, moduleName);

                    await _dbContext.AddAsync(new PalletVersionModel()
                    {
                        BlockchainName = _substrateService.BlockchainName,
                        PalletName = moduleName,
                        PalletVersion = lastVersion is not null ? lastVersion.PalletVersion + 1 : 0,
                        BlockStart = request.BlockStart,
                        BlockEnd = null,
                        SpecVersion = request.SpecVersion,
                    }, cancellationToken);
                }

                foreach (var moduleName in res.RemovedModules.Select(x => x.ModuleName))
                {
                    UpdateLastVersionWithBlockEnd(request.BlockStart, moduleName);
                }

                var nbRows = _dbContext.SaveChanges();
                var expectedRows = addedModules.Count + changedModules.Count * 2 + res.RemovedModules.Count();
                if (nbRows != expectedRows)
                {
                    _logger.LogWarning("[{handler}] Inserted rows are inconsistent. Expected (added module = {added} + changed modules * 2 {changed} + removed modules {removed} => {expectedResult} but was {result}", nameof(PalletVersionHandler), addedModules.Count, changedModules.Count * 2, res.RemovedModules.Count(), expectedRows, nbRows);
                }
                    //throw new InvalidOperationException("Inserted rows are inconsistent");

                stopwatch.Stop();

                _logger.LogInformation("[{handler}] Pallet version (total rows = {rows} | {added} new modules added | {changed} modules changed | {removed} modules removed). Analyzed in {timeMs}", nameof(PalletVersionHandler), nbRows, addedModules.Count, changedModules.Count * 2, res.RemovedModules.Count(), stopwatch.Elapsed.TotalMilliseconds);

                return Helpers.Ok(true);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "[{handler}] Error while comparing SpecVersion from block {previousBlockNumber} to block {blockStart}", nameof(SavedBlocksHandler), previousBlockNumber, request.BlockStart);

                _dbContext.SubstrateErrors.Add(new Infrastructure.Database.Contracts.Model.Errors.SubstrateErrorModel()
                {
                    BlockchainName = _substrateService.BlockchainName,
                    BlockNumber = request.BlockStart,
                    Date = DateTime.MinValue,
                    ElementId = 0,
                    TypeError = Infrastructure.Database.Contracts.Model.Errors.TypeErrorModel.SpecVersion,
                    Message = $"Error while comparing SpecVersion from block {previousBlockNumber} to block {request.BlockStart}. Exception : {ex.Message}"
                });

                await _dbContext.SaveChangesAsync(cancellationToken);

                return UseCaseError(ErrorResult.ErrorType.BusinessError, ex.Message);
            }
            
        }

        /// <summary>
        /// Convert metadata to v14
        /// </summary>
        /// <param name="metadataSource"></param>
        /// <param name="sourceVersion"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static MetadataV14 convertToV14(string metadataSource, MetadataVersion sourceVersion)
        {
            return sourceVersion switch
            {
                MetadataVersion.V9 => new MetadataV9(metadataSource).ToMetadataV14(),
                MetadataVersion.V10 => new MetadataV10(metadataSource).ToMetadataV14(),
                MetadataVersion.V11 => new MetadataV11(metadataSource).ToMetadataV14(),
                MetadataVersion.V12 => new MetadataV12(metadataSource).ToMetadataV14(),
                MetadataVersion.V13 => new MetadataV13(metadataSource).ToMetadataV14(),
                MetadataVersion.V14 => new MetadataV14(metadataSource),
                _ => throw new InvalidOperationException($"MetadataV{sourceVersion} comparison is not yet supported ! Stay tuned.")
            };
        }

        private PalletVersionModel? UpdateLastVersionWithBlockEnd(uint blockStart, string moduleName)
        {
            var palletDb = _dbContext.PalletVersionModels.Where(x => x.PalletName == moduleName);

            // This case when a 'changed' module is not already present in database
            if (!palletDb.Any())
                throw new InvalidOperationException($"{moduleName} has changed but is not present in the database");

            var lastVersion = palletDb.OrderBy(x => x.BlockStart).Last();
            lastVersion.BlockEnd = blockStart - 1;

            return lastVersion;
        }
    }
}
