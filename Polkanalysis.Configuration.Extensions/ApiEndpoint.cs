using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts;

namespace Polkanalysis.Configuration.Extensions
{
    public class ApiEndpoint : IApiEndpoint
    {
        public Uri? ApiUri { get; init; }

        public ApiEndpoint(IConfiguration configuration)
        {

            var apiUrl = configuration["Api:uri"];

            if (!string.IsNullOrEmpty(apiUrl))
                ApiUri = new Uri(apiUrl);
        }
    }
}
