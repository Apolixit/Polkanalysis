﻿using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Extrinsics;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Helper;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Monitored
{
    public class SavedExtrinsicsCommandValidator : AbstractValidator<SavedExtrinsicsCommand>
    {
        public SavedExtrinsicsCommandValidator(ISubstrateService substrateRepository)
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

    public class SavedExtrinsicsHandler : Handler<SavedExtrinsicsHandler, bool, SavedExtrinsicsCommand>
    {
        private readonly ISubstrateService _substrateService;
        private readonly IExplorerService _explorerService;
        private readonly ICoreService _coreService;
        private readonly SubstrateDbContext _db;
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly ILogger<SavedExtrinsicsHandler> logger;

        public SavedExtrinsicsHandler(ISubstrateService substrateService, IExplorerService explorerService, SubstrateDbContext db, ILogger<SavedExtrinsicsHandler> logger,
                                  IDistributedCache cache, ISubstrateDecoding substrateDecode, ICoreService coreService) : base(logger, cache)
        {
            _substrateService = substrateService;
            _explorerService = explorerService;
            _db = db;
            this.logger = logger;
            _substrateDecode = substrateDecode;
            _coreService = coreService;
        }

        public override async Task<Result<bool, ErrorResult>> HandleInnerAsync(SavedExtrinsicsCommand request, CancellationToken cancellationToken)
        {
            var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(new Substrate.NetApi.Model.Types.Base.BlockNumber(request.BlockNumber), cancellationToken);

            var (blockData, blockEvents, blockDate) = await WaiterHelper.WaitAndReturnAsync(
                _substrateService.Rpc.Chain.GetBlockAsync(blockHash, cancellationToken),
                _substrateService.At(request.BlockNumber).Storage.System.EventsAsync(cancellationToken),
                _coreService.GetDateTimeFromTimestampAsync(request.BlockNumber, cancellationToken)
            );

            var filteredExtrinsic = blockData.Block.Extrinsics.ToList();

            foreach (var extrinsic in filteredExtrinsic)
            {
                var extrinsicIndex = (uint)filteredExtrinsic.IndexOf(extrinsic);
                INode extrinsicDecode = default!;

                try
                {
                    extrinsicDecode = await _substrateDecode.DecodeExtrinsicAsync(extrinsic, blockHash, cancellationToken);
                    var status = _explorerService.GetExtrinsicsStatus(blockEvents, (int)extrinsicIndex);
                    var fees = await _explorerService.GetExtrinsicsFeesAsync(blockEvents, (int)extrinsicIndex, cancellationToken);
                    var lifetime = _explorerService.GetExtrinsicsLifetime(request.BlockNumber, extrinsic);
                    
                    EraLifetimeModel? lifetimeEntry = HandleLifetimeEntry(lifetime);

                    _db.ExtrinsicsInformation.Add(new Infrastructure.Database.Contracts.Model.Extrinsics.ExtrinsicsInformationModel()
                    {
                        BlockchainName = _substrateService.BlockchainName,
                        BlockNumber = request.BlockNumber,
                        ExtrinsicIndex = extrinsicIndex,
                        Lifetime = lifetimeEntry,
                        Method = extrinsicDecode.Name,
                        Event = extrinsicDecode.Children[0].Name,
                        TransactionVersion = extrinsic.TransactionVersion,
                        AccountAddress = extrinsic.Account is not null ? extrinsic.Account.ToString() : null,
                        IsSigned = extrinsic.Signed,
                        Signature = extrinsic.Signature is not null ? Utils.Bytes2HexString(extrinsic.Signature) : null,
                        Charge = null,
                        Status = status.Status.ToString(),
                        StatusMessage = status.Message,
                        Fees = fees,
                        BlockDate = blockDate
                    });

                    await _db.SaveChangesAsync(cancellationToken);

                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "[{handler}] Unable to decode extrinsic (index {extrinsicIndex}) from block {blockNumber}", nameof(SavedExtrinsicsHandler), extrinsicIndex, request.BlockNumber);

                    _db.SubstrateErrors.Add(new Infrastructure.Database.Contracts.Model.Errors.SubstrateErrorModel()
                    {
                        BlockchainName = _substrateService.BlockchainName,
                        BlockNumber = request.BlockNumber,
                        Date = blockDate,
                        ElementId = (uint)filteredExtrinsic.IndexOf(extrinsic),
                        TypeError = Infrastructure.Database.Contracts.Model.Errors.TypeErrorModel.Extrinsics,
                        Message = $"Unable to decode extrinsic (index {extrinsicIndex}) from block {request.BlockNumber}"
                    });

                    await _db.SaveChangesAsync(cancellationToken);

                    return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Unable to decode extrinsic (index {extrinsicIndex}) from block {request.BlockNumber}");
                }
            }

            return Helpers.Ok(true);
        }

        private EraLifetimeModel? HandleLifetimeEntry(LifetimeDto? lifetime)
        {
            EraLifetimeModel? lifetimeEntry = null;

            if (lifetime is not null)
            {
                lifetimeEntry = _db.EraLifetime.FirstOrDefault(x => x.IsImmortal == lifetime.IsImmortal && x.StartBlock == lifetime.FromBlock && x.EndBlock == lifetime.ToBlock);
                if (lifetimeEntry is null)
                {
                    lifetimeEntry = new Infrastructure.Database.Contracts.Model.Staking.EraLifetimeModel()
                    {
                        BlockchainName = _substrateService.BlockchainName,
                        IsImmortal = lifetime.IsImmortal,
                        StartBlock = lifetime.FromBlock,
                        EndBlock = lifetime.ToBlock
                    };
                    _db.EraLifetime.Add(lifetimeEntry);
                }
            }

            return lifetimeEntry;
        }
    }
}
