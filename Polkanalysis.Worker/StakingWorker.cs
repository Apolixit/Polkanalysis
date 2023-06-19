using MediatR;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Primary.Staking.Eras;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Polkanalysis.Infrastructure.Database.Repository.Staking;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Worker.Parameters.Context;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.DatabaseWorker
{
    public class StakingWorker
    {
        private readonly ISubstrateService _polkadotService;
        private readonly IMediator _mediator;
        private readonly ILogger<StakingWorker> _logger;
        private readonly PerimeterService _perimeterService;

        private EraPerimeter _eraPerimeter;

        public StakingWorker(
            ISubstrateService polkadotRepository,
            IMediator mediator,
            PerimeterService perimeterService,
            ILogger<StakingWorker> logger)
        {
            _polkadotService = polkadotRepository;
            _mediator = mediator;
            _logger = logger;
            _perimeterService = perimeterService;
        }

        protected uint GetLastEraId()
        {
            var lastEra = _polkadotService.Storage.Staking.CurrentEraAsync(CancellationToken.None).Result;
            return lastEra.Value;
        }

        public async Task RunAsync(CancellationToken stoppingToken)
        {
            _eraPerimeter = _perimeterService.GetEraPerimeter(GetLastEraId);
            if (_eraPerimeter.IsSet)
            {
                await RequestEraAsync(stoppingToken);
            }

            // Subscribe to new Era
            //await SubscribeErasAndSaveAsync(stoppingToken);
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
            await _polkadotService.Storage.Staking.SubscribeNewCurrentEraAsync(async (U32 eraId) =>
            {
                _logger.LogInformation($"New Era {eraId.Value} just started at {DateTime.Now}");

                await _mediator.Send(new EraStakersCommand()
                {
                    EraId = eraId.Value
                }, cancellationToken);

            },  cancellationToken);
        }

        public async Task RequestEraAsync(CancellationToken cancellationToken)
        {
            if (!_eraPerimeter.IsSet) throw new InvalidOperationException("Era perimeter is not properly set, please check your configuration file.");

            for (uint i = _eraPerimeter.From; i <= _eraPerimeter.To; i++)
            {
                await _mediator.Send(new EraStakersCommand()
                {
                    EraId = i,
                    OverrideIfAlreadyExist = _eraPerimeter.OverrideIfAlreadyExists
                }, cancellationToken);
            }
        }
    }
}
