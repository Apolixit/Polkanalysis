using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model
{
    public class BlockchainModel
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Current blockchain name (Polkadot, Kusama, Bajun ...)
        /// </summary>
        public required string BlockchainName { get; set; }
    }
}
