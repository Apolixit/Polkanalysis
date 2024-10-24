using System.Runtime.ConstrainedExecution;

namespace Polkanalysis.Domain.Contracts.Metrics
{
    public interface IDomainMetrics
    {
        /// <summary>
        /// Number of events analyzed
        /// </summary>
        /// <param name="blockchainName"></param>
        void IncreaseAnalyzedEventsCount(string blockchainName);

        /// <summary>
        /// Average time to analyse a full block by the worker
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blockchainName"></param>
        void RecordAverageTimeToAnalyzeAFullBlockByWorker(double value, string blockchainName);

        /// <summary>
        /// Average time to analyse a block
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blockchainName"></param>
        void RecordAverageTimeToAnalyzeBlocksForEachBlock(double value, string blockchainName);

        /// <summary>
        /// Average time to analyse events by block
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blockchainName"></param>
        void RecordAverageTimeToAnalyzeEventsForEachBlock(double value, string blockchainName);

        /// <summary>
        /// Average time to analyse extrinsics by block
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blockchainName"></param>
        void RecordAverageTimeToAnalyzeExtrinsicsForEachBlock(double value, string blockchainName);

        /// <summary>
        /// Ratio of analyzed events per block
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blockchainName"></param>
        void RecordRatioEventAnalyzed(double value, string blockchainName);
        void RecordRatioBlockAnalyzed(double value, string blockchainName);
    }
}