using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Internal;
using StrobeNet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Internal
{
    public class CacheManagerTests
    {
        private IDistributedCache _cache;

        [SetUp]
        public void Setup()
        {
            _cache = Substitute.For<IDistributedCache>();
        }

        [Test]
        public async Task HandleFromCacheAsync_WhenCacheHit_ReturnsCachedDataAsync()
        {
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var cachedData = JsonSerializer.Serialize("cached result");

            _cache.GetAsync(cacheKey, cancellationToken).Returns(Encoding.ASCII.GetBytes(cachedData));

            var result = await CacheManager.HandleFromCacheAsync<string>(
                _cache,
                cacheKey,
                () => Task.FromResult("non-cached result"),
                _ => true,
                60,
                logger,
                cancellationToken);

            Assert.That(result, Is.EqualTo("cached result"));
        }

        [Test]
        public async Task HandleFromCacheAsync_WhenCacheMiss_ExecutesNonCachedFuncAndCachesResultAsync()
        {
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var nonCachedResult = "non-cached result";

            _cache.GetAsync(cacheKey, cancellationToken).Returns((byte[])null!);

            var result = await CacheManager.HandleFromCacheAsync(
                _cache,
                cacheKey,
                () => Task.FromResult(nonCachedResult),
                _ => true,
                60,
                logger,
                cancellationToken);

            Assert.That(nonCachedResult, Is.EqualTo(result));
        }

        [Test]
        public async Task HandleFromCacheAsync_InvalidJsonCachedData_ExecutesNonCachedFuncAsync()
        {
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var invalidJsonCachedData = "invalid data";

            _cache.GetAsync(cacheKey, cancellationToken).Returns(Encoding.ASCII.GetBytes(invalidJsonCachedData));

            var result = await CacheManager.HandleFromCacheAsync(
                _cache,
                cacheKey,
                () => Task.FromResult("non-cached result"),
                _ => true,
                60,
                logger,
                cancellationToken);

            Assert.That(result, Is.EqualTo("non-cached result"));
        }

        [Test]
        public async Task HandleFromCacheAsync_WithInvalidCacheData_ExecutesNonCachedFuncAsync()
        {
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var nonCachedResult = "non-cached result";

            _cache.GetAsync(cacheKey, cancellationToken).Returns((byte[])null!);

            var result = await CacheManager.HandleFromCacheAsync(
                _cache,
                cacheKey,
                () => Task.FromResult(nonCachedResult),
                _ => false,
                60,
                logger,
                cancellationToken);

            Assert.That(nonCachedResult, Is.EqualTo(result));
        }
    }
}
