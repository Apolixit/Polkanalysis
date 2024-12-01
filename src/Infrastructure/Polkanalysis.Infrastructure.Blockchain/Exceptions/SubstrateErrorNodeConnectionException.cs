using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Exceptions
{
    public class SubstrateErrorNodeConnectionException : Exception
    {
        public string BlockchainName { get; internal set; }
        public string Provider { get; internal set; }
        public string Uri { get; internal set; }

        public SubstrateErrorNodeConnectionException(string blockchainName, string providerName, string uri, string message, Exception innerException) : 
            base($"[{blockchainName} ({providerName})] {message} ({innerException.Message})", innerException)
        {
            BlockchainName = blockchainName;
            Provider = providerName;
            Uri = uri;
        }

        public override string ToString()
        {
            return $"[{BlockchainName}] {base.ToString()} --> Inner Exception: {InnerException}";
        }
    }
}
