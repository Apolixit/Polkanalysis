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

namespace Polkanalysis.Domain.UseCase.Staking.Era
{
    public class EraStakersCommandHandler : Handler<EraStakersCommandHandler, bool, EraStakersCommand>
    {
        private readonly ISubstrateService _substrateService;
        private readonly IStakingDatabaseRepository _stakingDatabaseRepository;

        public EraStakersCommandHandler(
            IStakingDatabaseRepository stakingDatabaseRepository,
            ISubstrateService substrateService,
            ILogger<EraStakersCommandHandler> logger) : base(logger)
        {
            _stakingDatabaseRepository = stakingDatabaseRepository;
            _substrateService = substrateService;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(EraStakersCommand request, CancellationToken cancellationToken)
        {
            var eraId = new U32(request.EraId);

            var result = await _substrateService.Storage.Staking.ErasStakersQuery(eraId.Value).ExecuteAsync(cancellationToken);

            if (result == null || !result.Any())
            {
                _logger.LogError($"Era {eraId.Value} - Request for all EraStackers failed and give no answer");
                return UseCaseError(ErrorResult.ErrorType.BusinessError, $"No data");
            }
            else
            {
                _logger.LogInformation("Era {eraId} - Request for all EraStackers give {count} result", eraId.Value, result.Count);

                // Let's insert each record in database
                foreach ((BaseTuple<U32, SubstrateAccount>, Exposure) v in result)
                {
                    var validatorAccount = (SubstrateAccount)v.Item1.Value[1];
                    var exposure = v.Item2;

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
                        _stakingDatabaseRepository.InsertEraStakers(eraId, v);

                        _logger.LogInformation("The tuple (Era {eraId}, ValidatorAddress = {validatorAccount}) linked to {count} nominators successfully inserted in database", eraId.Value, validatorAccount.ToPolkadotAddress(), exposure.Others.Value.Length);
                    }
                }
            }

            return Helpers.Ok(true);
        }
    }
}
