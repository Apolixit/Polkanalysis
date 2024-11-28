using NUnit.Framework;
using NSubstitute;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System.Text.Json;
using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.UseCase;
using Substrate.NetApi.Extensions;
using Polkanalysis.Domain.Contracts;

namespace Polkanalysis.Domain.Tests.UseCase
{
    public class CommonBehaviorHandlerTests
    {
        private ILogger<ConcreteHandler> _logger;
        private IDistributedCache _cache;
        private ConcreteQuery _cachedRequest;
        private ConcreteQuery _request;
        private ConcreteHandler _handler;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<ConcreteHandler>>();
            _cache = Substitute.For<IDistributedCache>();
            _cachedRequest = new ConcreteQuery("Hey");
            _request = (ConcreteQuery)_cachedRequest;
            _handler = new ConcreteHandler(_logger, _cache);
        }

        [Test]
        public async Task Handle_ShouldReturnCachedResult_WhenCacheHitOccursAsync()
        {
            var cacheKey = "Hey_TestKey";
            var cachedData = JsonSerializer.Serialize(new SampleDto());
            _cache.GetAsync(cacheKey, Arg.Any<CancellationToken>()).Returns(cachedData.ToBytes());

            var result = await _handler.Handle(_request, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
        }
    }

    public class ConcreteQuery(string Name) : IRequest<Result<SampleDto, ErrorResult>>, ICached
    {
        public int CacheDurationInMinutes => Contracts.Settings.Constants.Cache.VeryFastCache;

        public string GenerateCacheKey()
        {
            return $"{Name}_TestKey";
        }
    }

    // Assuming a concrete implementation of Handler for testing
    public class ConcreteHandler : Handler<ConcreteHandler, SampleDto, ConcreteQuery>
    {
        public ConcreteHandler(ILogger<ConcreteHandler> logger, IDistributedCache cache) : base(logger, cache) { }

        public override async Task<Result<SampleDto, ErrorResult>> HandleInnerAsync(ConcreteQuery request, CancellationToken cancellationToken)
        {
            // Mock implementation for testing purposes
            return Helpers.Ok(new SampleDto());
        }
    }

    // Sample DTO class used for testing
    public class SampleDto {
        public bool Result { get; set; }
    }
}