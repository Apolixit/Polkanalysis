﻿using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Polkanalysis.Configuration.Extensions;

namespace Polkanalysis.Configuration.Tests
{
    public class MonitoringConfigurationTest
    {
        [Test]
        public void FilledMonitoringConfiguration_ShouldSucceed()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("Configs/Monitoring/appsettings_valid_monitoring.json", false)
                .Build();

            var monitoringConfig = new MonitoringEndpoint(config);

            Assert.That(monitoringConfig.PrometheusUri, Is.Not.Null);
            Assert.That(monitoringConfig.PrometheusUri.OriginalString, Is.EqualTo("https://localhost:1234"));

            Assert.That(monitoringConfig.GrafanaUri, Is.Not.Null);
            Assert.That(monitoringConfig.GrafanaUri.OriginalString, Is.EqualTo("https://localhost:3000"));

            Assert.That(monitoringConfig.OpentelemetryUri, Is.Not.Null);
            Assert.That(monitoringConfig.OpentelemetryUri.OriginalString, Is.EqualTo("https://localhost:4317"));

            Assert.That(monitoringConfig.ElasticSearchUri, Is.Null);
        }
    }
}
