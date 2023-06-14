using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Statistics;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Common.Database;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.UseCase.Price
{
    public class TokenPriceUseCase : UseCase<TokenPriceUseCase, TokenPriceDto, TokenPriceQuery>
    {
        private readonly HttpClient _httpClient;
        public TokenPriceUseCase(HttpClient httpClient, ILogger<TokenPriceUseCase> logger) : base(logger)
        {
            _httpClient = httpClient;
        }

        public async override Task<Result<TokenPriceDto, ErrorResult>> Handle(TokenPriceQuery request, CancellationToken cancellationToken)
        {
            //https://api.coingecko.com/api/v3/coins/polkadot/history?date=09-06-2023
            try
            {
                var requestResponse = await _httpClient.GetAsync($"https://api.coingecko.com/api/v3/coins/{request.CoinId}/history?date={request.Date.ToString("dd-MM-yyyy")}");

                _logger.LogTrace($"Get response : {requestResponse}");

                if (requestResponse.IsSuccessStatusCode)
                {
                    var responseString = await requestResponse.Content.ReadAsStringAsync();
                    var responseDto = JsonSerializer.Deserialize<CoinHistoryDto>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    var tokenPriceDto = new TokenPriceDto()
                    {
                        Price = responseDto.market_data.current_price.usd,
                        CompareToCurrency = CurrencyDto.USD,
                        Date = request.Date
                    };

                    return Helpers.Ok(tokenPriceDto);
                } else
                {
                    _logger.LogError("Error when requesting Coingecko API");
                }
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error when requesting Coingecko API");
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
    public class TokenPriceCommandUseCase : UseCase<TokenPriceUseCase, bool, TokenPriceCommand>
    {
        private readonly SubstrateDbContext _dbContext;

        public TokenPriceCommandUseCase(
            SubstrateDbContext dbContext, 
            ILogger<TokenPriceUseCase> logger) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async override Task<Result<bool, ErrorResult>> Handle(TokenPriceCommand command, CancellationToken cancellationToken)
        {
            _dbContext.TokenPrices.Add(new Infrastructure.Contracts.Database.Model.Price.TokenPriceModel()
            {
                BlockchainName = command.BlockchainName,
                Date = command.TokenPrice.Date,
                Price = command.TokenPrice.Price,
            });

            var nbRows = await _dbContext.SaveChangesAsync();
            if (nbRows != 1)
                throw new InvalidOperationException("Inserted rows are inconsistent");

            _logger.LogInformation($"{command.BlockchainName} token price : {command.TokenPrice.Price} at date {command.TokenPrice.Date} successfully inserted is database");

            return Helpers.Ok(true);
        }
    }
}
