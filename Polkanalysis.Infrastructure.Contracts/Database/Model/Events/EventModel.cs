﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Events
{
    public class EventModel
    {
        /// <summary>
        /// Current blockchain name (Polkadot, Kusama, Bajun ...)
        /// </summary>
        public required string BlockchainName { get; set; }

        /// <summary>
        /// Block number associated to this event
        /// </summary>
        public required int BlockId { get; set; }

        /// <summary>
        /// Block date time (calculated from block id)
        /// </summary>
        public required DateTime BlockDate { get; set; }

        /// <summary>
        /// Event index in current block
        /// </summary>
        public required int EventId { get; set; }

        /// <summary>
        /// Pallet name (Balances, System ...)
        /// </summary>
        public required string ModuleName { get; set; }

        /// <summary>
        /// Pallet event name
        /// </summary>
        public required string ModuleEvent { get; set; }

        [SetsRequiredMembers]
        public EventModel(string blockchainName, int blockId, DateTime blockDate, int eventId, string moduleName, string moduleEvent)
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
