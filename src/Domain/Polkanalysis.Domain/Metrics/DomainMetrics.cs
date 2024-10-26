using Microsoft.Extensions.Configuration;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Domain.UseCase.Monitored;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Metrics
{
    /// <summary>
    /// Custom metrics exposed by the domain
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DomainMetrics : IDomainMetrics
    {
        private Counter<int> CountEventsAnalyzed { get; set; }
        private Histogram<double> RatioOfEventsAnalyzedPerBlockHistogram { get; set; }
        private Histogram<double> RatioOfBlockAnalyzedHistogram { get; set; }
        private Histogram<double> AverageTimeToAnalyzeEventsForEachBlock { get; set; }
        private Histogram<double> AverageTimeToAnalyzeExtrinsicsForEachBlock { get; set; }
        private Histogram<double> AverageTimeToAnalyzeBlocksForEachBlock { get; set; }
        private Histogram<double> AverageTimeToAnalyzeAFullBlockByWorker { get; set; }
        private Histogram<double> AverageTimeToAnalyzeEraStakersByEra { get; set; }

        /// <summary>
        /// For unit i follow https://ucum.org/ucum for interoperability with Grafana, Prometheus and so on
        /// </summary>
        /// <param name="meterFactory"></param>
        /// <param name="configuration"></param>
        public DomainMetrics(IMeterFactory meterFactory, IConfiguration configuration)
        {
            var meter = meterFactory.Create("Polkanalysis.Domain.Metrics");

            // Counter of the number of blocks analyzed by the worker
            CountEventsAnalyzed = meter.CreateCounter<int>(
                "count.substrate.events.analyzed",
                "1",
                "Counter of the number of Substrate events inserted in the database");

            // Histogram of the ratio of Substrate succesfully parsed events analyzed by the worker
            RatioOfEventsAnalyzedPerBlockHistogram = meter.CreateHistogram<double>(
                "ratio_events_analyzed_per_block",
                "%",
                "Histogram of Substrate events analyzed by the worker");

            RatioOfBlockAnalyzedHistogram = meter.CreateHistogram<double>(
                "ratio_blocks_analyzed",
                "%",
                "Histogram which represent the number of block analyzed compare to the total number of block");

            AverageTimeToAnalyzeEventsForEachBlock = meter.CreateHistogram<double>(
                    "average_time_to_analyze_events_per_block",
                    "ms",
                    $"Histogram of average time to analyze all events by block ({nameof(SavedEventsHandler)})"
                );

            AverageTimeToAnalyzeExtrinsicsForEachBlock = meter.CreateHistogram<double>(
                    "average_time_to_analyze_extrinsics_per_block",
                    "ms",
                    $"Histogram of average time to analyze all extrinsics by block ({nameof(SavedExtrinsicsHandler)})"
                );

            AverageTimeToAnalyzeBlocksForEachBlock = meter.CreateHistogram<double>(
                    "average_time_to_analyze_events_per_block",
                    "ms",
                    $"Histogram of average time to analyze a block ({nameof(SavedBlocksHandler)})"
                );

            AverageTimeToAnalyzeAFullBlockByWorker = meter.CreateHistogram<double>(
                    "average_time_to_analyze_a_full_block_by_worker",
                    "ms",
                    $"Histogram of average time to analyze a full block by the background service");

            AverageTimeToAnalyzeEraStakersByEra = meter.CreateHistogram<double>(
                    "average_time_to_analyze_era_stakers_by_era",
                    "ms",
                    $"Histogram of average time to analyze the number of stakers for an era");
        }

        public void IncreaseAnalyzedEventsCount(string blockchainName) => CountEventsAnalyzed.Add(1, new KeyValuePair<string, object?>("blockchain", blockchainName));
        public void RecordRatioEventAnalyzed(double value, string blockchainName) => RatioOfEventsAnalyzedPerBlockHistogram.Record(value);
        public void RecordAverageTimeToAnalyzeEventsForEachBlock(double value, string blockchainName) => AverageTimeToAnalyzeEventsForEachBlock.Record(value, new KeyValuePair<string, object?>("blockchain", blockchainName));
        public void RecordAverageTimeToAnalyzeExtrinsicsForEachBlock(double value, string blockchainName) => AverageTimeToAnalyzeExtrinsicsForEachBlock.Record(value, new KeyValuePair<string, object?>("blockchain", blockchainName));
        public void RecordAverageTimeToAnalyzeBlocksForEachBlock(double value, string blockchainName) => AverageTimeToAnalyzeBlocksForEachBlock.Record(value, new KeyValuePair<string, object?>("blockchain", blockchainName));
        public void RecordAverageTimeToAnalyzeAFullBlockByWorker(double value, string blockchainName) => AverageTimeToAnalyzeAFullBlockByWorker.Record(value, new KeyValuePair<string, object?>("blockchain", blockchainName));
        public void RecordRatioBlockAnalyzed(double value, string blockchainName) => RatioOfBlockAnalyzedHistogram.Record(value, new KeyValuePair<string, object?>("blockchain", blockchainName));
        public void RecordAverageTimeToAnalyzeStakersByEra(double value, string blockchainName) => AverageTimeToAnalyzeEraStakersByEra.Record(value, new KeyValuePair<string, object?>("blockchain", blockchainName));
    }
}
