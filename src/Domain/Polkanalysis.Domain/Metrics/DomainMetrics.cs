using Microsoft.Extensions.Configuration;
using Polkanalysis.Domain.Contracts.Metrics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Metrics
{
    /// <summary>
    /// Custom metrics exposed by the domain
    /// </summary>
    public class DomainMetrics : IDomainMetrics
    {
        private Counter<int> CountEventsAnalyzed { get; set; }
        private Histogram<double> RatioOfEventsAnalyzedPerBlockHistogram { get; set; }

        public DomainMetrics(IMeterFactory meterFactory, IConfiguration configuration)
        {
            var meter = meterFactory.Create("Polkanalysis.Domain.Metrics");

            // Counter of the number of blocks analyzed by the worker
            CountEventsAnalyzed = meter.CreateCounter<int>(
                "count.substrate.events.analyzed",
                "block",
                "Counter of the number of Substrate events inserted in the database");

            // Histogram of the ratio of Substrate succesfully parsed events analyzed by the worker
            RatioOfEventsAnalyzedPerBlockHistogram = meter.CreateHistogram<double>(
                "ratio_events_analyzed_per_block",
                "block",
                "Histogram of Substrate events analyzed by the worker");
        }

        public void IncreaseAnalyzedEventsCount() => CountEventsAnalyzed.Add(1);
        public void RecordEventAnalyzed(double value) => RatioOfEventsAnalyzedPerBlockHistogram.Record(value);
    }
}
