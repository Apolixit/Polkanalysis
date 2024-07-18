using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Core;
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

namespace Polkanalysis.Domain.UseCase.Staking.Era
{
    public class EraStakersCommandValidator : AbstractValidator<EraStakersCommand>
    {
        public EraStakersCommandValidator(ISubstrateService substrateService)
        {
            RuleFor(x => x.EraId)
                .GreaterThan((uint)0)
                .MustAsync(async (x, token) =>
                {
                    // Just check if the current era is not > 76 era old, otherwise it is ok
                    var currentEra = await substrateService.Storage.Staking.CurrentEraAsync(token);

                    return currentEra <= x + 76;
                });
        }
    }

    public class EraStakersCommandHandler : Handler<EraStakersCommandHandler, bool, EraStakersCommand>
    {
        private readonly ISubstrateService _substrateService;
        private readonly IStakingDatabaseRepository _stakingDatabaseRepository;

        public EraStakersCommandHandler(
            IStakingDatabaseRepository stakingDatabaseRepository,
            ISubstrateService substrateService,
            ILogger<EraStakersCommandHandler> logger, IDistributedCache cache) : base(logger, cache)
        {
            _stakingDatabaseRepository = stakingDatabaseRepository;
            _substrateService = substrateService;
        }

        public async override Task<Result<bool, ErrorResult>> HandleInnerAsync(EraStakersCommand request, CancellationToken cancellationToken)
        {
            var eraId = new U32(request.EraId);

            var erasStakersQuery = await _substrateService.Storage.Staking.ErasStakersQueryAsync(eraId.Value, cancellationToken);
            var result = await erasStakersQuery.ExecuteAsync(cancellationToken);

            if (result == null || !result.Any())
            {
                _logger.LogWarning("Era {eraId} - Request for all EraStackers failed and give no answer", eraId.Value);
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

                    var alreadyExist = await _stakingDatabaseRepository.GetEraValidatorAsync((int)eraId.Value, validatorAccount, cancellationToken) != null;
                    bool canBeInserted = true;

                    if(alreadyExist)
                    {
                        _logger.LogDebug($"The tuple (Era {eraId.Value}, ValidatorAddress = {validatorAccount.ToPolkadotAddress()}) already exist in database");

                        if(request.OverrideIfAlreadyExist)
                        {
                            _logger.LogWarning($"Existing tuple (Era {eraId.Value}, ValidatorAddress = {validatorAccount.ToPolkadotAddress()}) will be override with new value");
                        } else
                        {
                            _logger.LogDebug("It won't be override, go to next item");
                            canBeInserted = false;
                        }
                    }

                    if(canBeInserted)
                    {
                        // Let's link the nominators to the validator
                        exposure = await _substrateService.Storage.Staking.ErasStakersAsync(new BaseTuple<U32, SubstrateAccount>(eraId, validatorAccount), cancellationToken);

                        _stakingDatabaseRepository.InsertEraStakers(eraId, tupleEraIdValidatorExposure);

                        _logger.LogInformation("The tuple (Era {eraId}, ValidatorAddress = {validatorAccount}) linked to {count} nominators successfully inserted in database", eraId.Value, validatorAccount.ToPolkadotAddress(), exposure.Others!.Value!.Length);
                    }
                }
            }

            return Helpers.Ok(true);
        }
    }
}
