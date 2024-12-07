using Microsoft.AspNetCore.Builder;
using Polkanalysis.Api.Gateway;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHttpClient();
builder.Services.AddSingleton<NSwagAggregator>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/swagger/v1/swagger.json", async (NSwagAggregator aggregator, HttpContext context) =>
{
    var document = await aggregator.AggregateSwaggerAsync();
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(document.ToJson());
});

app.UseOpenApi();
app.UseSwaggerUi(c =>
{
    c.DocumentPath = "/swagger/v1/swagger.json";
});

app.MapReverseProxy();

app.Run();
