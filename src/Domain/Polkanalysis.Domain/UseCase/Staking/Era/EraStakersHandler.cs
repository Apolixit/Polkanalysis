using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Microsoft.Extensions.Caching.Distributed;
using FluentValidation;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using System.Threading;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Domain.UseCase.Monitored;
using System.Diagnostics;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Domain.Contracts.Metrics;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Helper;

namespace Polkanalysis.Domain.UseCase.Staking.Era
{
    //public class EraStakersCommandValidator : AbstractValidator<EraStakersCommand>
    //{
    //    public EraStakersCommandValidator(ISubstrateService substrateService)
    //    {
    //        RuleFor(x => x.EraId)
    //            .GreaterThan((uint)0)
    //            .MustAsync(async (x, token) =>
    //            {
    //                // Just check if the current era is not > 76 era old, otherwise it is ok
    //                var currentEra = await substrateService.Storage.Staking.CurrentEraAsync(token);

    //                return currentEra <= x + 76;
    //            })
    //            .WithMessage(x => $"Only 76 last eras are saved. Current Era {x.EraId} is too old");
    //    }
    //}

    public class EraStakersCommandHandler : Handler<EraStakersCommandHandler, bool, EraStakersCommand>
    {
        private readonly ISubstrateService _substrateService;
        private readonly IStakingDatabaseRepository _stakingDatabaseRepository;
        private readonly SubstrateDbContext _db;
        private readonly IDomainMetrics _domainMetrics;

        public EraStakersCommandHandler(
            IStakingDatabaseRepository stakingDatabaseRepository,
            ISubstrateService substrateService,
            ILogger<EraStakersCommandHandler> logger, IDistributedCache cache, SubstrateDbContext db, IDomainMetrics domainMetrics) : base(logger, cache)
        {
            _stakingDatabaseRepository = stakingDatabaseRepository;
            _substrateService = substrateService;
            _db = db;
            _domainMetrics = domainMetrics;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(EraStakersCommand request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var eraId = new U32(request.EraId);

                var erasStakersQuery = await _substrateService.Storage.Staking.ErasStakersQueryAsync(eraId.Value, cancellationToken);
                var result = await erasStakersQuery.ExecuteAsync(cancellationToken);

                if (result == null || !result.Any())
                {
                    return UseCaseError(ErrorResult.ErrorType.BusinessError, $"Era {eraId.Value} - Request for all EraStackers failed and give no answer");
                }
                else
                {
                    _logger.LogInformation("Era {eraId} - Request for all EraStackers give {count} result", eraId.Value, result.Count);

                    // Let's insert each record in database
                    foreach ((BaseTuple<U32, SubstrateAccount>, Exposure) tupleEraIdValidatorExposure in result)
                    {
                        var validatorAccount = (SubstrateAccount)tupleEraIdValidatorExposure.Item1.Value[1];
                        var exposure = tupleEraIdValidatorExposure.Item2;

                        var (validatorDatabase, exposureUpdated) = await WaiterHelper.WaitAndReturnAsync(
                            _stakingDatabaseRepository.GetEraValidatorAsync((int)eraId.Value, validatorAccount, cancellationToken),
                            _substrateService.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(eraId, validatorAccount), cancellationToken)
                            );

                        var alreadyExist = validatorDatabase != null;

                        // Let's link the nominators to the validator
                        exposure = exposureUpdated;

                        // We have to do another call to get the nominators...
                        _stakingDatabaseRepository.InsertEraStakers(eraId, (new BaseTuple<U32, SubstrateAccount>(tupleEraIdValidatorExposure.Item1.Value[0].As<U32>(), validatorAccount), exposure));

                        _logger.LogDebug("The tuple (Era {eraId}, ValidatorAddress = {validatorAccount}) linked to {count} nominators successfully inserted in database", eraId.Value, validatorAccount.ToPolkadotAddress(), exposure.Others!.Value!.Length);
                    }
                }

                stopwatch.Stop();
                _logger.LogInformation("[{handler}] Sucessfully scan EraId {eraId} with {nbValidators} validators in {timeMs}ms", nameof(EraStakersCommandHandler), request.EraId, result.Count, stopwatch.Elapsed.TotalMilliseconds);

                _domainMetrics.RecordAverageTimeToAnalyzeStakersByEra(stopwatch.Elapsed.TotalMilliseconds, _substrateService.BlockchainName);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "[{handler}] Error while scanning EraId {eraId}", nameof(EraStakersCommandHandler), request.EraId);

                _db.SubstrateErrors.Add(new Infrastructure.Database.Contracts.Model.Errors.SubstrateErrorModel()
                {
                    BlockchainName = _substrateService.BlockchainName,
                    BlockNumber = 0,
                    Date = DateTime.MinValue,
                    ElementId = request.EraId,
                    TypeError = Infrastructure.Database.Contracts.Model.Errors.TypeErrorModel.EraStakers,
                    Message = $"Error while scanning EraId {request.EraId}. Exception : {ex.Message}"
                });

                await _db.SaveChangesAsync(cancellationToken);

                return UseCaseError(ErrorResult.ErrorType.BusinessError, ex.Message);
            }
            

            return Helpers.Ok(true);
        }
    }
}
