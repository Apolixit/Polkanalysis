﻿using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extensions
{
    public class MonitoringEndpoint : IMonitoringEndpoint
    {
        public Uri? PrometheusUri { get; set; }
        public Uri? GrafanaUri { get; set; }
        public Uri? ElasticSearchUri { get; set; }
        public bool IsMonitoringActivated { get; set; }
        public Uri? OpentelemetryUri { get; set; }

        public MonitoringEndpoint(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            var prometheusUri = configuration["Monitoring:Prometheus:uri"];
            var grafanaUri = configuration["Monitoring:Grafana:uri"];
            var elasticSearchUri = configuration["Monitoring:ElasticSearch:uri"];
            var opentelemetryUri = configuration["Monitoring:Opentelemetry:uri"];

            if (!string.IsNullOrEmpty(prometheusUri))
                PrometheusUri = new Uri(prometheusUri);

            if (!string.IsNullOrEmpty(grafanaUri))
                GrafanaUri = new Uri(grafanaUri);

            if (!string.IsNullOrEmpty(elasticSearchUri))
                ElasticSearchUri = new Uri(elasticSearchUri);

            if (!string.IsNullOrEmpty(opentelemetryUri))
                OpentelemetryUri = new Uri(opentelemetryUri);
        }
    }
}
