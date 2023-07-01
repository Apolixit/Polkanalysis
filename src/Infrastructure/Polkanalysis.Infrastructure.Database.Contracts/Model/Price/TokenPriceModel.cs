using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Price
{
    public class TokenPriceModel
    {/// <summary>
     /// Current blockchain name (Polkadot, Kusama, Bajun ...)
     /// </summary>
        public required string BlockchainName { get; set; }

        /// <summary>
        /// Price date
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// Token price
        /// </summary>
        public required double Price { get; set; }
    }
}
