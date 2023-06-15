using MediatR;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Domain.Helper;
using Polkanalysis.Infrastructure.Common.Database.Repository.Staking;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Staking;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.DatabaseWorker
{
    internal class StakingWorker
    {
        private readonly ISubstrateService _polkadotService;
        private readonly StakingDatabaseRepository _stakingDatabaseRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<StakingWorker> _logger;

        public StakingWorker(
            ISubstrateService polkadotRepository,
            IMediator mediator,
            StakingDatabaseRepository stakingDatabaseRepository,
            ILogger<StakingWorker> logger)
        {
            _polkadotService = polkadotRepository;
            _mediator = mediator;
            _stakingDatabaseRepository = stakingDatabaseRepository;
            _logger = logger;
        }

        /// <summary>
        /// Subscribe to new Era
        /// For each new Era we request all active validators and for each validator, nominators who voted for them
        /// And we insert everything in database to allow easier query by the front end
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SubscribeErasAndSaveAsync(CancellationToken cancellationToken)
        {
            var chainProperty = await _polkadotService.Rpc.System.PropertiesAsync(cancellationToken);

            await _polkadotService.Storage.Staking.SubscribeNewCurrentEraAsync(async (U32 eraId) =>
            {
                // A new Era start
                _logger.LogInformation($"New Era {eraId.Value} just started at {DateTime.Now}");

                var result = await _polkadotService.Storage.Staking.ErasStakersQuery(eraId.Value).ExecuteAsync(cancellationToken);

                if(result == null || !result.Any())
                {
                    _logger.LogError($"Era {eraId.Value} - Request for all EraStackers failed and give no answer");
                } else
                {
                    _logger.LogInformation($"Era {eraId.Value} - Request for all EraStackers give {result.Count} result");

                    // Let's insert each record in database

                    foreach((BaseTuple<U32, SubstrateAccount>, Exposure) v in result)
                    {
                        var validatorAccount = (SubstrateAccount)v.Item1.Value[1];
                        var exposure = v.Item2;

                        _stakingDatabaseRepository.InsertEraStakers(_polkadotService.BlockchainName, eraId, v);

                        _logger.LogDebug($"Era num {eraId.Value} - Validator {validatorAccount.ToPolkadotAddress()} linked to {exposure.Others.Value.Length} nominators successfully inserted in database");
                    }
                }
            },  cancellationToken);
        }
    }
}
