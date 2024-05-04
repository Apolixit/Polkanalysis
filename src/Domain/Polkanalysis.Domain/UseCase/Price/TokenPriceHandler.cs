using FluentValidation;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Price;
using System.Text.Json;

namespace Polkanalysis.Domain.UseCase.Price
{
    public class TokenPriceHandler : Handler<TokenPriceHandler, TokenPriceDto, TokenPriceQuery>
    {
        private readonly HttpClient _httpClient;
        public TokenPriceHandler(HttpClient httpClient, ILogger<TokenPriceHandler> logger) : base(logger)
        {
            _httpClient = httpClient;
        }

        public async override Task<Result<TokenPriceDto, ErrorResult>> Handle(TokenPriceQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(request)} is not set");

            //https://api.coingecko.com/api/v3/coins/polkadot/history?date=09-06-2023
            try
            {
                var requestResponse = await _httpClient.GetAsync($"https://api.coingecko.com/api/v3/coins/{request.CoinId}/history?date={request.Date.ToString("dd-MM-yyyy")}");

                _logger.LogTrace($"Get response : {requestResponse}");

                if (requestResponse.IsSuccessStatusCode)
                {
                    var responseString = await requestResponse.Content.ReadAsStringAsync();
                    var responseDto = JsonSerializer.Deserialize<CoinHistoryDto>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if(responseDto is null)
                    {
                        _logger.LogError("[{handlerName}] Error when deserializing Coingecko API response", nameof(TokenPriceHandler));
                        return UseCaseError(ErrorResult.ErrorType.BusinessError, $"CoinGecko deserialize to CoinHistoryDto failed");
                    }

                    var tokenPriceDto = new TokenPriceDto()
                    {
                        Price = responseDto.market_data.current_price.usd,
                        CompareToCurrency = CurrencyEnumDto.USD,
                        Date = request.Date
                    };

                    return Helpers.Ok(tokenPriceDto);
                } else
                {
                    _logger.LogError("[{handlerName}] Error when requesting Coingecko API", nameof(TokenPriceHandler));
                }
            } catch(Exception ex)
            {
                _logger.LogError(ex, "[{handlerName}] Error when requesting Coingecko API", nameof(TokenPriceHandler));
            }

            return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"Error...");
        }
    }

    public class TokenPriceCommandValidator : AbstractValidator<TokenPriceCommand>
    {
        public TokenPriceCommandValidator()
        {
            RuleFor(c => c.TokenPrice)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.TokenPrice.Price).GreaterThanOrEqualTo(0);
            RuleFor(c => c.TokenPrice.Date).NotNull();
        }
    }
    public class TokenPriceCommandHandler : Handler<TokenPriceCommandHandler, bool, TokenPriceCommand>
    {
        private readonly SubstrateDbContext _dbContext;

        public TokenPriceCommandHandler(
            SubstrateDbContext dbContext, 
            ILogger<TokenPriceCommandHandler> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(TokenPriceCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return UseCaseError(ErrorResult.ErrorType.EmptyParam, $"{nameof(command)} is not set");

            _dbContext.TokenPrices.Add(new TokenPriceModel()
            {
                BlockchainName = command.BlockchainName,
                Date = command.TokenPrice.Date.ToUniversalTime(),
                Price = command.TokenPrice.Price,
            });

            var nbRows = await _dbContext.SaveChangesAsync();
            if (nbRows != 1)
                throw new InvalidOperationException("Inserted rows are inconsistent");

            _logger.LogInformation("{BlockchainName} token price : {price} at date {priceDate} successfully inserted is database", command.BlockchainName, command.TokenPrice.Price, command.TokenPrice.Date);

            return Helpers.Ok(true);
        }
    }
}
