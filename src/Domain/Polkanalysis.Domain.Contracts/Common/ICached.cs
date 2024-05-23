using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Common
{
    public interface ICached
    {
        /// <summary>
        /// The duration in minutes for which the cache is valid.
        /// </summary>
        public int CacheDurationInMinutes { get; }

        /// <summary>
        /// Generates a cache key for the current request.
        /// </summary>
        /// <returns></returns>
        public string GenerateCacheKey();
    }
}
