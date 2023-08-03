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

namespace Polkanalysis.Domain.UseCase.Runtime.PalletVersion
{
    /// <summary>
    /// Get all pallet version for given pallet
    /// </summary>
    public class PalletVersionHandler : Handler<PalletVersionHandler, IEnumerable<PalletVersionDto>, PalletVersionsQuery>
    {
        private readonly SubstrateDbContext _dbContext;

        public PalletVersionHandler(SubstrateDbContext dbContext, ILogger<PalletVersionHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<IEnumerable<PalletVersionDto>, ErrorResult>> Handle(PalletVersionsQuery request, CancellationToken cancellationToken)
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
        private readonly IMetadataService _metadataService;

        public PalletVersionCommandHandler(
            SubstrateDbContext dbContext,
            IMetadataService metadataService,
            ISubstrateService substrateService,
            ILogger<PalletVersionCommandHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
            _substrateService = substrateService;
            _metadataService = metadataService;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(PalletVersionCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            // Now let's check pallet changed and also insert them in database to keep try of every
            if (request.BlockStart == 0)
                return UseCaseError(ErrorResult.ErrorType.EmptyModel, "Block start is 0, skip this one");

            var endPreviousBlockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(request.BlockStart - 1), cancellationToken);
            var metadataSource = await _substrateService.Rpc.State.GetMetaDataAtAsync(endPreviousBlockHash.Value, cancellationToken);

            var startBlockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new BlockNumber(request.BlockStart), cancellationToken);
            var metadataTarget = await _substrateService.Rpc.State.GetMetaDataAtAsync(startBlockHash.Value, cancellationToken);

            Guard.Against.NullOrEmpty(metadataSource);
            Guard.Against.NullOrEmpty(metadataTarget);

            // Just ensure previous block was on same Metadata, otherwise we don't do any comparison
            var sourceVersion = _metadataService.GetMetadataVersion(metadataSource);
            var targetVersion = _metadataService.GetMetadataVersion(metadataTarget);
            if (sourceVersion != targetVersion)
            {
                var response = $"New metadata major version (from {sourceVersion} to {targetVersion}, we don't do any comparison between major version";
                _logger.LogWarning(response);
                return UseCaseError(ErrorResult.ErrorType.BusinessError, response);
            }

            IMetadataDiffBase<IMetadataDifferentialModules> res = sourceVersion switch
            {
                MetadataVersion.V9 => _metadataService.MetadataCompareV9(new MetadataV9(metadataSource), new MetadataV9(metadataTarget)),
                MetadataVersion.V10 => _metadataService.MetadataCompareV10(new MetadataV10(metadataSource), new MetadataV10(metadataTarget)),
                MetadataVersion.V11 => _metadataService.MetadataCompareV11(new MetadataV11(metadataSource), new MetadataV11(metadataTarget)),
                MetadataVersion.V12 => _metadataService.MetadataCompareV12(new MetadataV12(metadataSource), new MetadataV12(metadataTarget)),
                MetadataVersion.V13 => _metadataService.MetadataCompareV13(new MetadataV13(metadataSource), new MetadataV13(metadataTarget)),
                MetadataVersion.V14 => _metadataService.MetadataCompareV14(new MetadataV14(metadataSource), new MetadataV14(metadataTarget)),
                _ => throw new InvalidOperationException($"MetadataV{sourceVersion} comparison is not yet supported ! Stay tuned.")
            };

            if (!res.ChangedModules.Any())
                _logger.LogWarning("No modules has changed, please check...");

            // First let's insert new modules
            foreach (var moduleName in res.AddedModules.Select(x => x.ModuleName))
            {
                await _dbContext.AddAsync(new PalletVersionModel()
                {
                    BlockchainName = _substrateService.BlockchainName,
                    PalletName = moduleName,
                    PalletVersion = 1,
                    BlockStart = request.BlockStart,
                    BlockEnd = null,
                }, cancellationToken);
            }

            foreach (var moduleName in res.ChangedModules.Select(x => x.ModuleName))
            {
                var lastVersion = UpdateLastVersionWithBlockEnd(request.BlockStart, moduleName);

                await _dbContext.AddAsync(new PalletVersionModel()
                {
                    BlockchainName = _substrateService.BlockchainName,
                    PalletName = moduleName,
                    PalletVersion = lastVersion.PalletVersion + 1,
                    BlockStart = request.BlockStart,
                    BlockEnd = null,
                }, cancellationToken);
            }

            foreach (var moduleName in res.RemovedModules.Select(x => x.ModuleName))
            {
                UpdateLastVersionWithBlockEnd(request.BlockStart, moduleName);
            }

            var nbRows = _dbContext.SaveChanges();
            if (nbRows != res.AddedModules.Count() + res.ChangedModules.Count() * 2 + res.RemovedModules.Count())
                throw new InvalidOperationException("Inserted rows are inconsistent");

            return true;
        }

        private PalletVersionModel UpdateLastVersionWithBlockEnd(uint blockStart, string moduleName)
        {
            var palletDb = _dbContext.PalletVersionModels.Where(x => x.PalletName.ToLowerInvariant() == moduleName.ToLowerInvariant());

            if (!palletDb.Any())
                throw new InvalidOperationException($"{moduleName} has changed but is not present in the database");

            var lastVersion = palletDb.OrderBy(x => x.BlockStart).Last();
            lastVersion.BlockEnd = blockStart - 1;

            return lastVersion;
        }
    }
}
