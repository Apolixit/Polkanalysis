using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts
{
    public interface IApiEndpoint
    {
        /// <summary>
        /// Api uri to request
        /// </summary>
        public Uri? ApiUri { get; init; }
    }
}
