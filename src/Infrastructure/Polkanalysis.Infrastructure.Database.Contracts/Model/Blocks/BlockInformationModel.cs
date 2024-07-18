using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Blocks
{
    /// <summary>
    /// Represent a block information detail
    /// </summary>
    public class BlockInformationModel
    {
        /// <summary>
        /// Current blockchain name (Polkadot, Kusama, Bajun ...)
        /// </summary>
        public required string BlockchainName { get; set; }

        /// <summary>
        /// The block number
        /// </summary>
        public required uint BlockNumber { get; set; }

        /// <summary>
        /// The block date
        /// </summary>
        public required DateTime BlockDate { get; set; }

        /// <summary>
        /// The block hash
        /// </summary>
        public required string BlockHash { get; set; }

        /// <summary>
        /// The validator substrate address
        /// </summary>
        public required string ValidatorAddress { get; set; }

        /// <summary>
        /// The number of events in the block
        /// </summary>
        public required uint EventsCount { get; set; }

        /// <summary>
        /// The number of extrinsics in the block
        /// </summary>
        public required uint ExtrinsicsCount { get; set; }

        /// <summary>
        /// The number of logs in the block
        /// </summary>
        public required uint LogsCount { get; set; }

        /// <summary>
        /// Block message
        /// </summary>
        public string? Justification { get; set; }
    }
}
