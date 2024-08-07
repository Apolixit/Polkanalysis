﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Common
{
    public class RangeDate
    {
        protected RangeDate() { }

        public RangeDate(DateTime? from, DateTime? to)
        {
            From = from;
            To = to;
        }

        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public static RangeDate Default => new RangeDate();
    }
}
