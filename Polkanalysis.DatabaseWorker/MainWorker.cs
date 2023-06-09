using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.DatabaseWorker
{
    public class MainWorker : BackgroundService
    {
        private readonly ISubstrateRepository _polkadotRepository;
        private readonly EventsWorker _eventsWorker;
        private readonly PriceWorker _priceWorker;
        private readonly ILogger<MainWorker> _logger;

        public MainWorker(
            ISubstrateRepository polkadotRepository,
            EventsWorker eventsWorker, 
            PriceWorker priceWorker, 
            ILogger<MainWorker> logger)
        {
            _polkadotRepository = polkadotRepository;
            _eventsWorker = eventsWorker;
            _priceWorker = priceWorker;
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
            // Connect to current blockchain
            await ConnectAsync(stoppingToken);

            // Listen event and insert it in database
            //await _eventsWorker.RunAsync(stoppingToken);

            // Store blockchain price in database every hour
            await _priceWorker.PriceFeedAsync(stoppingToken);
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
