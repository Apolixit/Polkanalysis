using FluentValidation;
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
            var blockDate = await _coreService.GetDateTimeFromTimestampAsync(request.BlockNumber, cancellationToken);

            try
            {
                var blockInfo = await _explorerService.GetBlockLightAsync(request.BlockNumber, cancellationToken);

                if (blockInfo.ValidatorAddress is null)
                    return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Block number {request.BlockNumber} has no validator");

                var alreadyExists = _db.BlockInformation.FirstOrDefault(x => x.BlockchainName == _substrateService.BlockchainName && x.BlockNumber == request.BlockNumber);

                var entity = new Infrastructure.Database.Contracts.Model.Blocks.BlockInformationModel()
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
                };

                if (alreadyExists is null)
                    _db.BlockInformation.Add(entity);
                else {
                    alreadyExists.BlockHash = blockInfo.Hash.Value;
                    alreadyExists.BlockDate = blockDate;
                    alreadyExists.EventsCount = blockInfo.NbEvents;
                    alreadyExists.ExtrinsicsCount = blockInfo.NbExtrinsics;
                    alreadyExists.LogsCount = blockInfo.NbLogs;
                    alreadyExists.ValidatorAddress = blockInfo.ValidatorAddress;
                    alreadyExists.Justification = blockInfo.Justification;
                }

                var nbRows = await _db.SaveChangesAsync();
                if (alreadyExists is null && nbRows != 1)
                {
                    return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Db rows are inconsistent. Should be 1 row inserted, but is {nbRows}");
                }

                stopwatch.Stop();
                _logger.LogInformation("[{handler}] Sucessfully scan block number {blockNum} ({blockDate}) in {timeMs}ms", nameof(SavedBlocksHandler), request.BlockNumber, blockDate, stopwatch.Elapsed.TotalMilliseconds);

                _domainMetrics.RecordAverageTimeToAnalyzeBlocksForEachBlock(stopwatch.Elapsed.TotalMilliseconds, _substrateService.BlockchainName);
                
            } catch(Exception ex)
            {
                _logger.LogError(ex, "[{handler}] Error while scanning block number {blockNum}", nameof(SavedBlocksHandler), request.BlockNumber);

                _db.SubstrateErrors.Add(new Infrastructure.Database.Contracts.Model.Errors.SubstrateErrorModel()
                {
                    BlockchainName = _substrateService.BlockchainName,
                    BlockNumber = request.BlockNumber,
                    Date = blockDate,
                    ElementId = 0,
                    TypeError = Infrastructure.Database.Contracts.Model.Errors.TypeErrorModel.Blocks,
                    Message = $"Error while scanning block number {request.BlockNumber}. Exception : {ex.Message}"
                });

                await _db.SaveChangesAsync(cancellationToken);

                return UseCaseError(ErrorResult.ErrorType.BusinessError, ex.Message);
            }

            return Helpers.Ok(true);
        }
    }
}
