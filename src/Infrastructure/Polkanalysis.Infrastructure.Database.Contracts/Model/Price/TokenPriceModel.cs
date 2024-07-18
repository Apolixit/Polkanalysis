using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Price
{
    public class TokenPriceModel : BlockchainModel
    {
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
