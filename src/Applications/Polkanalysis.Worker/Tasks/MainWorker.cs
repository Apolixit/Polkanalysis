using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Worker.Tasks
{
    public class MainWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly EventsWorker _eventsWorker;
        private readonly StakingWorker _stakingWorker;
        private readonly PriceWorker _priceWorker;
        private readonly VersionWorker _versionWorker;
        private readonly ILogger<MainWorker> _logger;

        public MainWorker(
            ISubstrateService polkadotRepository,
            EventsWorker eventsWorker,
            StakingWorker stakingWorker,
            PriceWorker priceWorker,
            VersionWorker versionWorker,
            ILogger<MainWorker> logger)
        {
            _polkadotRepository = polkadotRepository;
            _eventsWorker = eventsWorker;
            _stakingWorker = stakingWorker;
            _priceWorker = priceWorker;
            _versionWorker = versionWorker;
            _logger = logger;
        }

        /// <summary>
        /// Connect to current blockchain
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConnectAsync(CancellationToken cancellationToken)
        {
            if (!_polkadotRepository.IsConnected())
            {
                await _polkadotRepository.ConnectAsync();
                _logger.LogInformation($"Succesfully connected to {_polkadotRepository.BlockchainName}");
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await ExecuteTaskAsync(stoppingToken);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured, try to connect again !");
                await ExecuteAsync(stoppingToken);
            }
            
        }

        public async Task ExecuteTaskAsync(CancellationToken stoppingToken)
        {
            // Connect to current blockchain
            await ConnectAsync(stoppingToken);

            // Listen event and insert it in database
            //await _eventsWorker.RunAsync(stoppingToken);

            // Subscribe to new Era
            //await _stakingWorker.RunAsync(stoppingToken);

            // Store blockchain price in database every hour
            //await _priceWorker.RunAsync(stoppingToken);

            // Subscribe to Runtime and Pallet upgrade version
            await _versionWorker.RunAsync(stoppingToken);
        }

        /// <summary>
        /// Disconnect when leaving
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await _polkadotRepository.CloseAsync();
            _logger.LogInformation($"Succesfully disconnected to {_polkadotRepository.BlockchainName}");

            await base.StopAsync(cancellationToken);
        }
    }
}
