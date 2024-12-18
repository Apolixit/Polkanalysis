using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using NSwag.AspNetCore;
using Polkanalysis.Api.Gateway;
using Polkanalysis.Hub;
using Polkanalysis.Infrastructure.Database.Hub;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Yarp.ReverseProxy.Model;
using Yarp.ReverseProxy.Swagger;
using Yarp.ReverseProxy.Swagger.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApiDocument();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

var proxyCnfiguration = builder.Configuration.GetSection("ReverseProxy");
builder.Services.AddReverseProxy()
    .LoadFromConfig(proxyCnfiguration)
    .AddSwagger(proxyCnfiguration);

builder.Services.AddPolkanalysisSignalRServices(builder.Configuration);

//builder.Services.AddHttpClient();
//builder.Services.AddSingleton<NSwagAggregator>();

builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Polkanalysis Aggregated API";
    options.Version = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.MapGet("/swagger/v1/swagger.json", async (NSwagAggregator aggregator, HttpContext context) =>
//{
//    var document = await aggregator.AggregateSwaggerAsync();
//    context.Response.ContentType = "application/json";
//    await context.Response.WriteAsync(document.ToJson());
//});

//app.UseOpenApi();
//app.UseSwaggerUi(c =>
//{
//    c.DocumentPath = "/swagger/v1/swagger.json";
//});

app.UseSwaggerUI(options =>
{
    var config = app.Services.GetRequiredService<IOptionsMonitor<ReverseProxyDocumentFilterConfig>>().CurrentValue;
    foreach (var cluster in config.Clusters)
    {
        options.SwaggerEndpoint($"/swagger/{cluster.Key}/swagger.json", cluster.Key);
    }
});

//app.UseSwaggerUi(options =>
//{
//    var config = app.Services.GetRequiredService<IOptionsMonitor<ReverseProxyDocumentFilterConfig>>().CurrentValue;
//    foreach (var cluster in config.Clusters)
//    {
//        options.SwaggerRoutes.Add(new SwaggerUiRoute(cluster.Key, $"/swagger/{cluster.Key}/swagger.json"));
//    }
//});

app.UseRouting();
app.UseSignalRConfiguration();
app.UseMiddleware<ApiKeyMiddleware>();
app.MapReverseProxy();

app.Run();
