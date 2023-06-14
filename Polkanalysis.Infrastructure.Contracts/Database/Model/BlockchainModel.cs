using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model
{
    public class BlockchainModel
    {
        /// <summary>
        /// Current blockchain name (Polkadot, Kusama, Bajun ...)
        /// </summary>
        public required string BlockchainName { get; set; }
    }
}
