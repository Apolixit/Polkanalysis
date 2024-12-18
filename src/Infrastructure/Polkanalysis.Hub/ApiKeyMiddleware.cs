namespace Polkanalysis.Hub
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IApiKeyValidator apiKeyValidator)
        {
            //if (!context.Request.Headers.TryGetValue("POLKANALYSIS-X-API-KEY", out var extractedApiKey))
            //{
            //    context.Response.StatusCode = 401; // Unauthorized
            //    await context.Response.WriteAsync("API Key is missing.");
            //    return;
            //}

            //if (!apiKeyValidator.Validate(extractedApiKey!, out var validApiKey))
            //{
            //    context.Response.StatusCode = 403; // Forbidden
            //    await context.Response.WriteAsync("Invalid API Key.");
            //    return;
            //}

            //// Ajouter les permissions dans le contexte pour les utiliser plus tard
            //context.Items[PolkanalysisHub.ApiKeyPermission] = validApiKey.AllowedChannels;

            await _next(context);
        }
    }
}
