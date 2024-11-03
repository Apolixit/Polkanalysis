using Microsoft.Extensions.Configuration;
using System.Configuration;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Ardalis.GuardClauses;

namespace Polkanalysis.Configuration.Extensions
{
    public class SubstrateEndpoint : ISubstrateEndpoint
    {
        //public string BlockchainName { get; set; }
        //public Uri WsEndpointUri { get; set; }
        public Uri? ApiUri { get; set; }
        public Uri? PrometheusUri { get; set; }

        private List<Endpoints> _endpoints = new List<Endpoints>();
        public List<Endpoints> Endpoints => _endpoints;

        public SubstrateEndpoint(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            var substrateEndpoints = configuration.GetSection("SubstrateEndpoints").GetChildren().ToList();

            foreach(var endpoint in substrateEndpoints)
            {
                var elems = endpoint.GetChildren().First(x => x.Key == "Endpoints");
                _endpoints.Add(new Endpoints()
                {
                    BlockchainName = endpoint["name"]!,
                    Uris = elems.GetChildren().Select(x => {
                        var child = x.GetChildren().First();
                        return new EndpointInformation()
                        {
                            Name = child.Key,
                            Uri = new Uri(child.Value!)
                        };
                    }).ToList()
                });
            }

            if (_endpoints.Count == 0)
                throw new ConfigurationErrorsException("Error in configuration file. No SubstrateEndpoints node has been declared");
        }

        /// <summary>
        /// For a given blockchain, return by default the first endpoint of the list
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <returns></returns>
        public EndpointInformation GetEndpoint(string blockchainName)
        {
            Guard.Against.NullOrEmpty(blockchainName);

            return _endpoints.First(x => x.BlockchainName == blockchainName).Uris.First();
        }

        /// <summary>
        /// For a given blockchain, return the following endpoint (the next element of the list)
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="currentEndpointUri"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public EndpointInformation GetNextEndpoint(string blockchainName, string currentEndpointUri)
        {
            Guard.Against.NullOrEmpty(blockchainName);
            Guard.Against.NullOrEmpty(currentEndpointUri);

            var uris = _endpoints.Single(x => x.BlockchainName == blockchainName).Uris;
            var index = uris.FindIndex(x => x.Uri.OriginalString == currentEndpointUri);

            if (index == -1)
                throw new InvalidOperationException($"No endpoint has been found for Blockchain {blockchainName} and uri {currentEndpointUri}");

            // Return the next index, and return to 0 if the current endpoint was the last element
            return uris[(index + 1) % uris.Count];
        }

        /// <summary>
        /// For a given blockchain, return an endpoint by his provider name
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="currentEndpointUri"></param>
        /// <returns></returns>
        public EndpointInformation GetEndpointByProviderName(string blockchainName, string providerName)
        {
            Guard.Against.NullOrEmpty(blockchainName);
            Guard.Against.NullOrEmpty(providerName);

            return _endpoints.Single(x => x.BlockchainName == blockchainName).Uris.Single(x => x.Name == providerName);
        }
    }
}