using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts
{
    public interface ISubstrateEndpoint
    {
        /// <summary>
        /// Substrate blockchain name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Substrate string endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// Substrate Uri endpoint
        /// </summary>
        public Uri EndPointUri { get; }
    }
}
