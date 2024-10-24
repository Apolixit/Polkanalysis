using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using Polkanalysis.Domain.Contracts.Metrics;
using Polkanalysis.Domain.Metrics;
using System.Diagnostics.Metrics;

namespace Polkanalysis.Domain.Tests.Metrics
{
    public class DomainMetricsTests
    {
        private IDomainMetrics _domainMetrics;
        private IMeterFactory _meterFactory;

        private static IServiceProvider MockServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var config = MockConfiguration();

            //serviceCollection.AddMetrics();
            serviceCollection.AddSingleton(config);
            serviceCollection.AddSingleton<IDomainMetrics, DomainMetrics>();

            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration MockConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"WorkerMeterName", "Polkanalysis.Domain.Metrics"}
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();
        }

        [SetUp]
        public void Setup()
        {
            var serviceProvider = MockServiceProvider();
            _domainMetrics = serviceProvider.GetRequiredService<IDomainMetrics>();
            _meterFactory = serviceProvider.GetRequiredService<IMeterFactory>();
        }

        [TearDown]
        public void TearDown()
        {
            _meterFactory.Dispose();
        }

        [Test, Ignore("Debug serviceCollection.AddMetrics();")]
        public void WorkerMetrics_IncreaseBlockCount()
        {
            var collector = new MetricCollector<int>(_meterFactory, "Polkanalysis.Domain.Metrics", "count.substrate.events.analyzed");

            _domainMetrics.IncreaseAnalyzedEventsCount("Polkadot");

            var measure = collector.GetMeasurementSnapshot();
            Assert.That(measure[0].Value, Is.EqualTo(1));
        }
    }
}
