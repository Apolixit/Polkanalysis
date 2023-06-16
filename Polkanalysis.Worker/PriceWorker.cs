using MediatR;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.DatabaseWorker
{
    public class PriceWorker
    {
        private readonly ISubstrateService _polkadotRepository;
        private readonly IMediator _mediator;
        private readonly ILogger<PriceWorker> _logger;

        private bool canUpdate = true;
        public PriceWorker(
            ISubstrateService polkadotRepository,
            IMediator mediator, 
            ILogger<PriceWorker> logger)
        {
            _polkadotRepository = polkadotRepository;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Request price feed every hours and insert in into database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task PriceFeedAsync(CancellationToken cancellationToken)
        {
            // We start a new hour
            var currentDate = DateTime.Now;
            if(currentDate.Minute == 0 && canUpdate)
            {
                _logger.LogInformation($"New hour start ({currentDate.ToString("dd-MM-yyyy HH:mm:ss")}), fetch price feed for {_polkadotRepository.BlockchainName} network");

                var tokenPriceResult = await _mediator.Send(new TokenPriceQuery()
                {
                    CoinId = _polkadotRepository.BlockchainName.ToLower()
                });

                _logger.LogInformation($"Price result = {tokenPriceResult}");

                // Let's insert the price in database
                await _mediator.Send(new TokenPriceCommand()
                {
                    BlockchainName = _polkadotRepository.BlockchainName,
                    TokenPrice = new Domain.Contracts.Dto.Price.TokenPriceDto()
                    {
                        Price = tokenPriceResult.Value.Price,
                        Date = currentDate.ToUniversalTime(),
                        CompareToCurrency = Domain.Contracts.Dto.Price.CurrencyDto.USD
                    }
                }, cancellationToken);

                _logger.LogInformation($"{currentDate.ToString("dd-MM-yyyy HH:mm:ss")} {_polkadotRepository.BlockchainName} price {tokenPriceResult.Value.Price} inserted in database");
                canUpdate = false;
            } else
            {
                canUpdate = true;
            }
        }
    }
}
