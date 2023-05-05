using Polkanalysis.Configuration.Contracts;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Polkanalysis.Configuration.Extentions
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
            var apiSection = configuration.GetSection("Api").GetChildren().ToList();
            var pometheusSection = configuration.GetSection("Prometheus").GetChildren().ToList();
            
            var blockchainNameSection = substrateSection.FirstOrDefault(e => e.Key == "Name");
            var substrateEndpointSection = substrateSection.FirstOrDefault(e => e.Key == "Endpoint");
            var apiUriSection = apiSection.FirstOrDefault(e => e.Key == "uri");
            var prometheusUriSection = pometheusSection.FirstOrDefault(e => e.Key == "uri");

            if (blockchainNameSection == null || blockchainNameSection.Value == null)
                throw new ConfigurationErrorsException($"{nameof(blockchainNameSection)} is not set");

            BlockchainName = blockchainNameSection.Value;

            if (substrateEndpointSection == null || substrateEndpointSection.Value == null)
                throw new ConfigurationErrorsException($"{nameof(substrateEndpointSection)} is not set");

            WsEndpointUri = new Uri(substrateEndpointSection.Value);

            if(apiUriSection != null && apiUriSection.Value != null)
                ApiUri = new Uri(apiUriSection.Value);

            if (prometheusUriSection != null && prometheusUriSection.Value != null)
                PrometheusUri = new Uri(prometheusUriSection.Value);
        }
    }
}