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

        /// <summary>
        /// Api uri to request
        /// </summary>
        public Uri? ApiUri { get; set; }

        /// <summary>
        /// Prometheus uri
        /// </summary>
        public Uri? PrometheusUri { get; set; }
    }
}
