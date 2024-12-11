using Polkanalysis.Hub;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Hub
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        //private readonly SubstrateDbContext _db;
        private readonly ConcurrentDictionary<string, ApiKey> _apiKeys = new();

        //public ApiKeyValidator(SubstrateDbContext db)
        public ApiKeyValidator()
        {
            //_db = db;

            _apiKeys.TryAdd("key1", new ApiKey("key1",["Event1Notification"]));
            _apiKeys.TryAdd("key1", new ApiKey("key2", ["Event2Notification", "Event1Notification"]));
        }

        public bool Validate(string apiKey, out ApiKey validApiKey)
        {
            return _apiKeys.TryGetValue(apiKey, out validApiKey);
        }
    }
}
