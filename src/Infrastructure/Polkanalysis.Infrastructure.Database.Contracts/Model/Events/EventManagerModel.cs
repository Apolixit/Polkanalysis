using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class EventManagerModel : BlockchainModel
    {
        /// <summary>
        /// Pallet name (Balances, System ...)
        /// </summary>
        public required string ModuleName { get; set; }

        /// <summary>
        /// Pallet event name
        /// </summary>
        public required string ModuleEvent { get; set; }

        /// <summary>
        /// Last block number when this event has been scanned
        /// </summary>
        public int LastOccurenceScannedBlockId { get; set; }

        /// <summary>
        /// Last block number when this event has been scanned
        /// </summary>
        public int LastScanBlockId { get; set; }
    }
}
