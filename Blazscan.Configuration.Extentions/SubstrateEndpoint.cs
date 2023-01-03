using Blazscan.Configuration.Contracts;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Blazscan.Configuration.Extentions
{
    public class SubstrateEndpoint : ISubstrateEndpoint
    {
        public const string ENDPOINT = "SubstrateEndpoint";

        public string Name { get; set; }
        public string Endpoint { get; set; }
        public Uri EndPointUri => new Uri(Endpoint);

        public SubstrateEndpoint(IConfiguration configuration)
        {
            if (configuration == null) 
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            var section = configuration.GetSection(ENDPOINT).GetChildren().ToList();

            var nameSection = section.FirstOrDefault(e => e.Key == "Name");
            var endpointSection = section.FirstOrDefault(e => e.Key == "Endpoint");

            if (nameSection == null || nameSection.Value == null)
                throw new ConfigurationErrorsException($"{nameof(nameSection)} is not set");

            if (endpointSection == null || endpointSection.Value == null)
                throw new ConfigurationErrorsException($"{nameof(endpointSection)} is not set");

            Name = nameSection.Value;
            Endpoint = endpointSection.Value;
        }
    }
}