namespace Polkanalysis.Configuration.Contracts.Endpoints
{
    public interface ISubstrateEndpoint
    {
        /// <summary>
        /// The list of all the endpoints (all blockchains)
        /// </summary>
        public List<Endpoints> Endpoints { get; }

        /// <summary>
        /// Get the main endpoint given a blockchain name
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <returns></returns>
        public EndpointInformation GetEndpoint(string blockchainName);

        /// <summary>
        /// For a given blockchain, return an endpoint by his provider name
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="providerName"></param>
        /// <returns></returns>
        EndpointInformation GetEndpointByProviderName(string blockchainName, string providerName);

        /// <summary>
        /// Get the next endpoint in the list given a blockchain name and the current endpoint
        /// </summary>
        /// <param name="blockchainName"></param>
        /// <param name="currentEndpointUri"></param>
        /// <returns></returns>
        public EndpointInformation GetNextEndpoint(string blockchainName, string currentEndpointUri);
    }

    public class Endpoints
    {
        /// <summary>
        /// Substrate blockchain name
        /// </summary>
        public string BlockchainName { get; set; } = string.Empty;

        /// <summary>
        /// Node Uri endpoint
        /// </summary>
        public List<EndpointInformation> Uris { get; set; } = default!;
    }

    /// <summary>
    /// Endpoint provider name + the uri
    /// </summary>
    public class EndpointInformation
    {
        public string Name { get; set; } = string.Empty;
        public Uri Uri { get; set; } = default!;
    }
}
