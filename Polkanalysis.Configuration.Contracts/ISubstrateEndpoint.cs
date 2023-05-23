namespace Polkanalysis.Configuration.Contracts
{
    public interface ISubstrateEndpoint
    {
        /// <summary>
        /// Substrate blockchain name
        /// </summary>
        public string BlockchainName { get; set; }

        /// <summary>
        /// Node Uri endpoint
        /// </summary>
        public Uri WsEndpointUri { get; }
    }
}
