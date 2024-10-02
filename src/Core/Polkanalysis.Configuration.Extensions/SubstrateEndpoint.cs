using Polkanalysis.Configuration.Contracts;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Polkanalysis.Configuration.Extensions
{
    public class SubstrateEndpoint : ISubstrateEndpoint
    {
        public string BlockchainName { get; set; }
        public Uri WsEndpointUri { get; set; }
        public Uri? ApiUri { get; set; }
        public Uri? PrometheusUri { get; set; }

        public SubstrateEndpoint(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            var substrateSection = configuration.GetSection("SubstrateEndpoint").GetChildren().ToList();

            var blockchainNameSection = substrateSection.Find(e => e.Key == "Name");
            var substrateEndpointSection = substrateSection.Find(e => e.Key == "Endpoint");

            if (blockchainNameSection == null || blockchainNameSection.Value == null)
                throw new ConfigurationErrorsException($"{nameof(blockchainNameSection)} is not set");

            BlockchainName = blockchainNameSection.Value;

            if (substrateEndpointSection == null || substrateEndpointSection.Value == null)
                throw new ConfigurationErrorsException($"{nameof(substrateEndpointSection)} is not set");

            WsEndpointUri = new Uri(substrateEndpointSection.Value);
        }
    }
}