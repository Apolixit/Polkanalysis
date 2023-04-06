﻿using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Contracts.Database.Analysis.Events
{
    public class EventElementFactory
    {
        public EventElementFactory(IDatabaseInsert databaseInsert, RuntimeEvent runtimeEvent, Enum eventValue)
        {
            DatabaseInsert = databaseInsert;
            RuntimeEvent = runtimeEvent;
            EventValue = eventValue;
        }

        public IDatabaseInsert DatabaseInsert { get; set; }
        public RuntimeEvent RuntimeEvent { get; set; }
        public Enum EventValue { get; set; }
    }
}
