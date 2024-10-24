using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class EventModel : BlockchainModel
    {
        /// <summary>
        /// Block number associated to this event
        /// </summary>
        public required uint BlockId { get; set; }

        /// <summary>
        /// Block date time (calculated from block id)
        /// </summary>
        public required DateTime BlockDate { get; set; }

        /// <summary>
        /// Event index in current block
        /// </summary>
        public required uint EventId { get; set; }

        /// <summary>
        /// Pallet name (Balances, System ...)
        /// </summary>
        public required string ModuleName { get; set; }

        /// <summary>
        /// Pallet event name
        /// </summary>
        public required string ModuleEvent { get; set; }

        [SetsRequiredMembers]
        public EventModel(string blockchainName, uint blockId, DateTime blockDate, uint eventId, string moduleName, string moduleEvent)
        {
            BlockchainName = blockchainName;
            BlockId = blockId;
            BlockDate = blockDate;
            EventId = eventId;
            ModuleName = moduleName;
            ModuleEvent = moduleEvent;
        }

        public bool IsEqual(EventModel eventModel)
        {
            return
                BlockchainName == eventModel.BlockchainName &&
                BlockId == eventModel.BlockId &&
                BlockDate == eventModel.BlockDate &&
                EventId == eventModel.EventId &&
                ModuleName == eventModel.ModuleName &&
                ModuleEvent == eventModel.ModuleEvent;
        }
    }
}
