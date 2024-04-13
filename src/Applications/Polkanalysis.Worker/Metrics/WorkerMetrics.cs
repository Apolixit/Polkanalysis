using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Worker.Metrics
{
    /// <summary>
    /// Metrics exposed by the worker
    /// Documentation: 
    ///     https://learn.microsoft.com/en-us/dotnet/core/diagnostics/observability-with-otel
    ///     https://www.mytechramblings.com/posts/getting-started-with-opentelemetry-metrics-and-dotnet-part-1/
    ///     https://www.mytechramblings.com/posts/getting-started-with-opentelemetry-metrics-and-dotnet-part-2/
    /// </summary>
    public class WorkerMetrics
    {
        private Counter<int> CountBlockAnalyzed { get; set; }
        private Counter<int> CountEventsAnalyzed { get; set; }
        private Histogram<double> RatioOfEventsAnalyzedPerBlockHistogram { get; set; }
        private Histogram<int> TimeDurationOfEventsAnalyzedPerBlockHistogram { get; set; }

        public WorkerMetrics(IMeterFactory meterFactory, IConfiguration configuration)
        {
            var meter = meterFactory.Create("Polkanalysis.Worker.Metrics" ?? throw new NullReferenceException("WorkerMeterName is not defined in appSettings.json"));

            // Counter of the number of blocks analyzed by the worker
            CountBlockAnalyzed = meter.CreateCounter<int>(
                "count.blocks.analyzed",
                "block",
                "Counter of the number of blocks analyzed by the worker");

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

            TimeDurationOfEventsAnalyzedPerBlockHistogram = meter.CreateHistogram<int>(
                "time_duration_events_analyzed_per_block",
                "block",
                "");
        }

        public void IncreaseBlockCount() => CountBlockAnalyzed.Add(1);
        public void IncreaseAnalyzedEventsCount() => CountEventsAnalyzed.Add(1);
        public void RecordEventAnalyzed(double value) => RatioOfEventsAnalyzedPerBlockHistogram.Record(value);
        public void RecordEventAnalyzed(int value) => TimeDurationOfEventsAnalyzedPerBlockHistogram.Record(value);
    }
}
