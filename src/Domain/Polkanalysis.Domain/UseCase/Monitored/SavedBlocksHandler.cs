﻿using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Monitored
{
    public class SavedBlocksCommandValidator : AbstractValidator<SavedBlocksCommand>
    {
        public SavedBlocksCommandValidator(ISubstrateService substrateRepository)
        {
            RuleFor(x => x.BlockNumber)
                .GreaterThan((uint)0)
                .MustAsync(async (x, token) =>
                {
                    // The block number must be less than or equal to the current block number
                    var blockNum = await substrateRepository.Rpc.Chain.GetHeaderAsync(token);
                    return x <= blockNum.Number.Value;
                });
        }
    }

    public class SavedBlocksHandler : Handler<SavedBlocksHandler, bool, SavedBlocksCommand>
    {
        private readonly ISubstrateService _substrateService;
        private readonly IExplorerService _explorerService;
        private readonly ICoreService _coreService;
        private readonly IDomainMetrics _domainMetrics;
        private readonly SubstrateDbContext _db;

        public SavedBlocksHandler(ISubstrateService substrateService,
                                  SubstrateDbContext db,
                                  IExplorerService explorerService,
                                  ICoreService coreService,
                                  ILogger<SavedBlocksHandler> logger,
                                  IDistributedCache cache,
                                  IDomainMetrics domainMetrics) : base(logger, cache)
        {
            _substrateService = substrateService;
            _db = db;
            _explorerService = explorerService;
            _coreService = coreService;
            _domainMetrics = domainMetrics;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedBlocksCommand request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();
            var blockInfo = await _explorerService.GetBlockLightAsync(request.BlockNumber, cancellationToken);

            if (blockInfo.ValidatorAddress is null)
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Block number {request.BlockNumber} has no validator");

            if (_db.BlockInformation.Any(x => x.BlockNumber == request.BlockNumber))
            {
                _logger.LogDebug("[{handler}] Block number {blockNum} is not inserted into {tableName} because it already exists", nameof(SavedBlocksHandler), request.BlockNumber, nameof(_db.BlockInformation));
                return Helpers.Ok(true);
            }

            var blockDate = await _coreService.GetDateTimeFromTimestampAsync(request.BlockNumber, cancellationToken);

            _db.BlockInformation.Add(new Infrastructure.Database.Contracts.Model.Blocks.BlockInformationModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                BlockHash = blockInfo.Hash.Value,
                BlockDate = blockDate,
                BlockNumber = request.BlockNumber,
                EventsCount = blockInfo.NbEvents,
                ExtrinsicsCount = blockInfo.NbExtrinsics,
                LogsCount = blockInfo.NbLogs,
                ValidatorAddress = blockInfo.ValidatorAddress,
                Justification = blockInfo.Justification
            });

            var nbRows = await _db.SaveChangesAsync();

            if (nbRows != 1)
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Db rows are inconsistent. Should be 1 row inserted, but is {nbRows}");
            }

            stopwatch.Stop();
            _logger.LogInformation("[{handler}] Sucessfully scan block number {blockNum} ({blockDate}) in {timeMs}ms", nameof(SavedBlocksHandler), request.BlockNumber, blockDate, stopwatch.Elapsed.TotalMilliseconds);

            _domainMetrics.RecordAverageTimeToAnalyzeBlocksForEachBlock(stopwatch.Elapsed.TotalMilliseconds, _substrateService.BlockchainName);
            return Helpers.Ok(true);
        }
    }
}
