using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Internal
{
    public static class CacheManager
    {
        /// <summary>
        /// Handles retrieving data from cache or executing a non-cached function and caching the result.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="cache">The distributed cache instance.</param>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="nonCachedFunc">The function to execute if the data is not found in the cache.</param>
        /// <param name="isResutValid">The function to validate the result.</param>
        /// <param name="durationInMinutes">The duration in minutes to cache the result.</param>
        /// <param name="logger">The logger instance.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The cached result or the result from the non-cached function.</returns>
        public static async Task<TResult> HandleFromCacheAsync<TResult>(
            this HybridCache cache,
            string cacheKey,
            Func<Task<TResult>> nonCachedFunc,
            Func<TResult?, bool> isResultValid,
            int durationInMinutes,
            List<string> tags,
            CancellationToken cancellationToken)
        {
            return await cache.GetOrCreateAsync(cacheKey, async entry => {
                return await nonCachedFunc();
            }, new HybridCacheEntryOptions()
            {
                LocalCacheExpiration = TimeSpan.FromMinutes(durationInMinutes),
                Expiration = TimeSpan.FromMinutes(durationInMinutes)
            }, tags: tags, 
            cancellationToken);
        }
    }
}
