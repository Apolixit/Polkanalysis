using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Configuration.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Exceptions
{
    /// <summary>
    /// Custom exception when too many request to a node are made
    /// </summary>
    internal class TooManyRequestsException : Exception
    {
        public EndpointInformation Endpoint { get; private set; }

        public TooManyRequestsException(EndpointInformation endpoint) 
            : base($"Too many requests. Endpoint : {endpoint.Name} {endpoint.Uri}")
        {
            Endpoint = endpoint;
        }
}
}
