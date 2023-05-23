using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Extentions
{
    public class MonitoringEndpoint : IMonitoringEndpoint
    {
        public Uri? PrometheusUri { get; set; }
        public Uri? GrafanaUri { get; set; }
        public Uri? ElasticSearchUri { get; set; }

        public MonitoringEndpoint(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ConfigurationErrorsException($"{nameof(configuration)} is not set");

            
            var pometheusSection = configuration.GetSection("Prometheus").GetChildren().ToList();
            var grafanaSection = configuration.GetSection("Grafana").GetChildren().ToList();
            var elasticSearchSection = configuration.GetSection("ElasticSearch").GetChildren().ToList();
            
            var prometheusUriSection = pometheusSection.FirstOrDefault(e => e.Key == "uri");
            var grafanaUriSection = grafanaSection.FirstOrDefault(e => e.Key == "uri");
            var elasticSearchUriSection = elasticSearchSection.FirstOrDefault(e => e.Key == "uri");

            if (prometheusUriSection != null && prometheusUriSection.Value != null)
                PrometheusUri = new Uri(prometheusUriSection.Value);

            if (grafanaUriSection != null && grafanaUriSection.Value != null)
                GrafanaUri = new Uri(grafanaUriSection.Value);

            if (elasticSearchUriSection != null && elasticSearchUriSection.Value != null)
                ElasticSearchUri = new Uri(elasticSearchUriSection.Value);
        }
    }
}
