﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Events
{
    public class LinkedEventAttribute : Attribute
    {
        public string LinkedEvent { get; set; }

        public LinkedEventAttribute(string linkedEvent)
        {
            LinkedEvent = linkedEvent;
        }
    }
}
