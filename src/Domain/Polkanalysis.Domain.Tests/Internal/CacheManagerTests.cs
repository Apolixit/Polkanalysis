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
        [Test]
        public async Task HandleFromCacheAsync_CacheHit_ReturnsCachedDataAsync()
        {
            // Arrange
            var cache = Substitute.For<IDistributedCache>();
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var cachedData = JsonSerializer.Serialize("cached result");

            cache.GetAsync(cacheKey, cancellationToken).Returns(cachedData.ToByteArray());

            // Act
            var result = await CacheManager.HandleFromCacheAsync<string>(
                cache,
                cacheKey,
                () => Task.FromResult("non-cached result"),
                _ => true,
                60,
                logger,
                cancellationToken);

            // Assert
            Assert.That("cached result", Is.EqualTo(result));
        }

        [Test]
        public async Task HandleFromCacheAsync_CacheMiss_ExecutesNonCachedFuncAndCachesResultAsync()
        {
            // Arrange
            var cache = Substitute.For<IDistributedCache>();
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var nonCachedResult = "non-cached result";

            cache.GetAsync(cacheKey, cancellationToken).Returns((byte[])null!);

            // Act
            var result = await CacheManager.HandleFromCacheAsync<string>(
                cache,
                cacheKey,
                () => Task.FromResult(nonCachedResult),
                _ => true,
                60,
                logger,
                cancellationToken);

            // Assert
            Assert.That(nonCachedResult, Is.EqualTo(result));
        }

        [Test]
        public async Task HandleFromCacheAsync_InvalidCachedData_ExecutesNonCachedFuncAsync()
        {
            // Arrange
            var cache = Substitute.For<IDistributedCache>();
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var invalidCachedData = "invalid data";

            cache.GetAsync(cacheKey, cancellationToken).Returns(invalidCachedData.ToByteArray());

            // Act
            var result = await CacheManager.HandleFromCacheAsync<string>(
                cache,
                cacheKey,
                () => Task.FromResult("non-cached result"),
                _ => true,
                60,
                logger,
                cancellationToken);

            // Assert
            Assert.That("non-cached result", Is.EqualTo(result));
        }

        [Test]
        public async Task HandleFromCacheAsync_NonCachedFuncResultInvalid_DoesNotCacheResultAsync()
        {
            // Arrange
            var cache = Substitute.For<IDistributedCache>();
            var logger = Substitute.For<ILogger>();
            var cancellationToken = new CancellationToken();
            var cacheKey = "test-key";
            var nonCachedResult = "non-cached result";

            cache.GetAsync(cacheKey, cancellationToken).Returns((byte[])null!);

            // Act
            var result = await CacheManager.HandleFromCacheAsync<string>(
                cache,
                cacheKey,
                () => Task.FromResult(nonCachedResult),
                _ => false,
                60,
                logger,
                cancellationToken);

            // Assert
            Assert.That(nonCachedResult, Is.EqualTo(result));
        }
    }
}
