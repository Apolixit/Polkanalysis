using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
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
        private readonly SubstrateDbContext _db;

        public SavedBlocksHandler(ISubstrateService substrateService,
                                  SubstrateDbContext db,
                                  IExplorerService explorerService,
                                  ILogger<SavedBlocksHandler> logger,
                                  IDistributedCache cache) : base(logger, cache)
        {
            _substrateService = substrateService;
            _db = db;
            _explorerService = explorerService;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedBlocksCommand request, CancellationToken cancellationToken)
        {
            var blockInfo = await _explorerService.GetBlockLightAsync(request.BlockNumber, cancellationToken);

            if (blockInfo.Validator is null)
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Block number {request.BlockNumber} has no validator");
            if (_db.BlockInformation.Any(x => x.BlockNumber == request.BlockNumber))
            {
                _logger.LogDebug($"Block number {request.BlockNumber} is not inserted into {nameof(_db.BlockInformation)} because it already exists");
                return Helpers.Ok(true);
            }

            _db.BlockInformation.Add(new Infrastructure.Database.Contracts.Model.Blocks.BlockInformationModel()
            {
                BlockchainName = _substrateService.BlockchainName,
                BlockHash = blockInfo.Hash.Value,
                BlockNumber = request.BlockNumber,
                EventsCount = blockInfo.NbEvents,
                ExtrinsicsCount = blockInfo.NbExtrinsics,
                LogsCount = blockInfo.NbLogs,
                ValidatorAddress = blockInfo.Validator.SubstrateAddress
            });

            var nbRows = await _db.SaveChangesAsync();

            if (nbRows != 1)
            {
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Db rows are inconsistent. Should be 1 row inserted, but is {nbRows}");
            }

            _logger.LogInformation($"Block number {request.BlockNumber} has been inserted into {nameof(_db.BlockInformation)}");

            return Helpers.Ok(true);
        }
    }
}
