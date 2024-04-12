using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Configuration.Contracts
{
    public interface IMonitoringEndpoint
    {
        /// <summary>
        /// Prometheus uri
        /// </summary>
        public Uri? PrometheusUri { get; set; }

        public Uri? GrafanaUri { get; set; }
        public Uri? ElasticSearchUri { get; set; }
        public Uri? OpentelemetryUri { get; set;}
    }
}
