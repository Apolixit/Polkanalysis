using NSwag;

namespace Polkanalysis.Api.Gateway
{
    /// <summary>
    /// Build a aggregation of all swagger of the Substrate APIs
    /// </summary>
    public class NSwagAggregator
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<NSwagAggregator> _logger;

        public NSwagAggregator(HttpClient httpClient, ILogger<NSwagAggregator> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<OpenApiDocument> AggregateSwaggerAsync()
        {
            var swaggerUrls = new[]
        {
            "https://localhost:7067/swagger/v1/swagger.json"
        };

            var aggregatedDocument = new OpenApiDocument();

            foreach (var url in swaggerUrls)
            {
                var swaggerJson = await _httpClient.GetStringAsync(url);
                var document = await OpenApiDocument.FromJsonAsync(swaggerJson);

                // Fusionner les endpoints
                foreach (var path in document.Paths)
                {
                    aggregatedDocument.Paths[path.Key] = path.Value;
                }

                // Ajouter les schémas (éviter les conflits de noms si nécessaire)
                foreach (var schema in document.Components.Schemas)
                {
                    var schemaKey = schema.Key;

                    // Évitez les collisions en ajustant le nom si besoin
                    if (aggregatedDocument.Components.Schemas.ContainsKey(schemaKey))
                    {
                        schemaKey = $"{schema.Key}_{document.Info.Title}";
                    }

                    aggregatedDocument.Components.Schemas[schemaKey] = schema.Value;
                }
            }

            _logger.LogInformation("Swagger aggregation completed");

            return aggregatedDocument;
        }
    }
}
