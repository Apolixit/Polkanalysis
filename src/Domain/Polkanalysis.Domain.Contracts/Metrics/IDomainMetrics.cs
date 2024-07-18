namespace Polkanalysis.Domain.Contracts.Metrics
{
    public interface IDomainMetrics
    {
        void IncreaseAnalyzedEventsCount();
        void RecordEventAnalyzed(double value);
    }
}