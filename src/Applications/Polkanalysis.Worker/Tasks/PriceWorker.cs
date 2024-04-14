using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Worker.Parameters;
using Polkanalysis.Worker.Parameters.Context;

namespace Polkanalysis.Worker.Tasks
{
    public class PriceWorker : BackgroundService
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<PriceWorker> _logger;
        private readonly PerimeterService _perimeterService;
        private readonly TimeSpan _checkPeriod = TimeSpan.FromSeconds(30);

        private TokenPricePerimeter _priceTokenPerimeter;

        public PriceWorker(
            ISubstrateService polkadotRepository,
            IMediator mediator,
            PerimeterService perimeterService,
            ILogger<PriceWorker> logger)
        {
            _polkadotRepository = polkadotRepository;
            _mediator = mediator;
            _perimeterService = perimeterService;
            _logger = logger;

            _priceTokenPerimeter = perimeterService.GetTokenPricePerimeter(FirstDayToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected DateTime FirstDayToken()
        {
            return new DateTime(2022, 01, 01);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RunAsync(stoppingToken);
        }

        /// <summary>
        /// We mix two logic here, because our goal is to get price value every hour (and only one time per hour) of the token price
        ///     - First we check if
        ///     - Second we check if we are seeking for old price
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task RunAsync(CancellationToken cancellationToken)
        {
            // First of all, we check if we need to fetch previous days and if we have token price in our database
            var missingDates = new List<DateTime>();

            if (_priceTokenPerimeter.IsSet)
            {
                _logger.LogInformation("[{workerName}] Fetch price from {from} to {to}", nameof(PriceWorker), _priceTokenPerimeter.From.ToString("dd-MM-yyyy"), _priceTokenPerimeter.To.ToString("dd-MM-yyyy"));

                var historicalPrice = await _mediator.Send(new HistoricalPriceQuery()
                {
                    From = _priceTokenPerimeter.From,
                    To = _priceTokenPerimeter.To,
                }, cancellationToken);

                var dayRange = Math.Abs(_priceTokenPerimeter.From.Subtract(_priceTokenPerimeter.To).Days);
                var rangeDateTimeFromBeggining = Enumerable.Range(0, dayRange)
                    .Select(day => _priceTokenPerimeter.From.AddDays(day));

                if (rangeDateTimeFromBeggining is not null && rangeDateTimeFromBeggining.Any())
                {
                    missingDates = rangeDateTimeFromBeggining
                        .Select(d => d.Date)
                        .Except(historicalPrice.Value.TokenPrices.Select(x => x.Date.Date))
                        .ToList();
                }

                if(missingDates.Any())
                    _logger.LogInformation("[{workerName}] {dateMissingCount} dates are missing from the database", nameof(PriceWorker), missingDates.Count());
                else
                    _logger.LogInformation("[{workerName}] No dates are missing from the database", nameof(PriceWorker));
            }

            using PeriodicTimer timer = new PeriodicTimer(_checkPeriod);

            while (!cancellationToken.IsCancellationRequested && await timer.WaitForNextTickAsync())
            {
                _logger.LogDebug("[{workerName}] Price new {second}s ticks ", nameof(PriceWorker), _checkPeriod.Seconds);

                var hasInsert = await PriceFeedAsync(cancellationToken);

                if (!hasInsert && missingDates.Any())
                {
                    var missingDate = missingDates.First();
                    _logger.LogInformation("[{workerName}] Price feed : no new price has been inserted, keep insert old date {oldDate}", nameof(PriceWorker), missingDate);

                    await GetPriceAndInsertAsync(missingDate, cancellationToken);

                    if (missingDates.Remove(missingDate))
                    {
                        _logger.LogDebug("[{workerName}] {missingDate} successfully remove from missing dates", nameof(PriceWorker), missingDate);
                    }
                    else
                    {
                        _logger.LogError("[{workerName}] Error when trying to remove {missingDate} from missing dates", nameof(PriceWorker), missingDate);
                    }
                }
            }
        }

        /// <summary>
        /// Request price feed every days and insert in into database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>True if a new price has been inserted</returns>
        public async Task<bool> PriceFeedAsync(CancellationToken cancellationToken)
        {
            // We start a new day
            var currentDate = DateTime.Now;
            if (currentDate.Hour == 0)
            {
                _logger.LogInformation("[{workerName}] New hour start ({currentDate}), fetch price feed for {BlockchainName} network", nameof(PriceWorker), currentDate.ToString("dd-MM-yyyy HH:mm:ss"), _polkadotRepository.BlockchainName);
                await GetPriceAndInsertAsync(currentDate, cancellationToken);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Get a price at given data (from Coingecko) and insert it in database
        /// </summary>
        /// <param name="currentDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task GetPriceAndInsertAsync(DateTime currentDate, CancellationToken cancellationToken)
        {
            var tokenPriceResult = await _mediator.Send(new TokenPriceQuery()
            {
                CoinId = _polkadotRepository.BlockchainName.ToLower(),
                Date = currentDate.Date
            });

            _logger.LogInformation("[{workerName}] Price result = {priceResult}", nameof(PriceWorker), tokenPriceResult.Value);

            // Let's insert the price in database
            await _mediator.Send(new TokenPriceCommand()
            {
                BlockchainName = _polkadotRepository.BlockchainName,
                TokenPrice = new Domain.Contracts.Dto.Price.TokenPriceDto()
                {
                    Price = tokenPriceResult.Value.Price,
                    Date = currentDate.Date,
                    CompareToCurrency = Domain.Contracts.Dto.Price.CurrencyEnumDto.USD
                }
            }, cancellationToken);

            _logger.LogInformation("[{workerName}] {currentDate} {BlockchainName} price {tokenPrice} inserted in database", nameof(PriceWorker), currentDate.ToString("dd-MM-yyyy HH:mm:ss"), _polkadotRepository.BlockchainName, tokenPriceResult.Value.Price);
        }
    }
}
