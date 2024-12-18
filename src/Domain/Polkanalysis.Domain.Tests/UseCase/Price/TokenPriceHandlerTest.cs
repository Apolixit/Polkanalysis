using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Parachain;
using Polkanalysis.Domain.Contracts.Primary.Price;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Parachain;
using Polkanalysis.Domain.UseCase.Price;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Price
{
    public class TokenPriceHandlerTest : UseCaseTest<TokenPriceHandler, TokenPriceDto, TokenPriceQuery>
    {
        [SetUp]
        public void Start()
        {
            _logger = Substitute.For<ILogger<TokenPriceHandler>>();
            _useCase = new TokenPriceHandler(null!, _logger, Substitute.For<HybridCache>());
        }

        //[TearDown]
        //public void End()
        //{
        //    _httpClient.Dispose();
        //}

        [Test]
        public async Task TokenPriceHandler_WithValidApiResponse_ShouldReturnTokenPriceDtoAsync()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When("https://api.coingecko.com/api/v3/coins/*")
                .Respond("application/json", "{\"market_data\":{\"current_price\":{\"usd\":10}}}");

            _useCase = new TokenPriceHandler(mockHttp.ToHttpClient(), _logger!, Substitute.For<HybridCache>());

            var timeNow = DateTime.Now.ToUniversalTime();
            var result = await _useCase!.HandleInnerAsync(
                new TokenPriceQuery() { 
                    CoinId = "polkadot", 
                    Date = timeNow 
                }, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Date, Is.EqualTo(timeNow));
            Assert.That(result.Value.Price, Is.EqualTo(10));
        }

        [Test]
        public async Task TokenPriceHandler_WithInvalidApiResponse_ShouldReturnUseCaseErrorAsync()
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("https://api.coingecko.com/api/v3/coins/*").RespondMatchSummary(System.Net.HttpStatusCode.NotFound);
            _useCase = new TokenPriceHandler(mockHttp.ToHttpClient(), _logger!, Substitute.For<HybridCache>());

            var result = await _useCase!.HandleInnerAsync(new TokenPriceQuery()
            {
                CoinId = "polkadot",
                Date = new DateTime(2024, 1, 1)
            },CancellationToken.None);

            Assert.That(result.IsError, Is.True);
        }
    }
}
