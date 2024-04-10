using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using Polkanalysis.Worker.Metrics;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Worker.Tests.Metrics
{
    public class WorkerMetricsTests
    {
        private WorkerMetrics _workerMetrics;
        private IMeterFactory _meterFactory;

        private static IServiceProvider MockServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var config = MockConfiguration();

            serviceCollection.AddMetrics();
            serviceCollection.AddSingleton(config);
            serviceCollection.AddSingleton<WorkerMetrics>();

            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration MockConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"WorkerMeterName", "Polkanalysis.Worker.Metrics"}
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings!)
                .Build();
        }

        [SetUp]
        public void Setup()
        {
            var serviceProvider = MockServiceProvider();
            _workerMetrics = serviceProvider.GetRequiredService<WorkerMetrics>();
            _meterFactory = serviceProvider.GetRequiredService<IMeterFactory>();
        }

        [TearDown]
        public void TearDown()
        {
            _meterFactory.Dispose();
        }

        [Test]
        public void WorkerMetrics_IncreaseBlockCount()
        {
            var collector = new MetricCollector<int>(_meterFactory, "Polkanalysis.Worker.Metrics", "count.blocks.analyzed");
            
            _workerMetrics.IncreaseBlockCount();

            var measure = collector.GetMeasurementSnapshot();
            Assert.That(measure[0].Value, Is.EqualTo(1));
        }
    }
}
