using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.Extensions.Logging;
using Ardalis.GuardClauses;
using Polkanalysis.Configuration.Contracts.Api;

namespace Polkanalysis.Components.Services.Http
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _apiUri;
        private readonly ILogger<ApiService> _logger;

        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public ApiService(
            HttpClient httpClient, 
            IApiEndpoint _apiEndpoint,
            ILogger<ApiService> logger)
        {
            _httpClient = httpClient;

            if(_apiEndpoint.ApiUri == null)
                throw new ArgumentException(nameof(_apiEndpoint.ApiUri));

            _apiUri = _apiEndpoint.ApiUri;
            _logger = logger;
        }

        private string getUrl(string url)
        {
            return _apiUri.AbsoluteUri.Substring(0, _apiUri.AbsoluteUri.Length - 1) + url;
        }

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHTTP = await _httpClient.GetAsync(getUrl(url));

            _logger.LogTrace($"Get response : {responseHTTP}");
            if (responseHTTP.IsSuccessStatusCode)
            {
                var response = await Deserialize<T>(responseHTTP, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<T>(response, true, responseHTTP);
            }
            else
            {
                return new HttpResponseWrapper<T>(default!, false, responseHTTP);
            }
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(getUrl(url), stringContent);
            return new HttpResponseWrapper<object>(null!, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(getUrl(url), stringContent);
            if (response.IsSuccessStatusCode)
            {
                var responseDeserialized = await Deserialize<TResponse>(response, defaultJsonSerializerOptions);
                return new HttpResponseWrapper<TResponse>(responseDeserialized, true, response);
            }
            else
            {
                return new HttpResponseWrapper<TResponse>(default, false, response);
            }
        }

        public async Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T data)
        {
            var dataJson = JsonSerializer.Serialize(data);
            var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(getUrl(url), stringContent);
            return new HttpResponseWrapper<object>(default!, response.IsSuccessStatusCode, response);
        }

        public async Task<HttpResponseWrapper<object>> DeleteAsync(string url)
        {
            var responseHTTP = await _httpClient.DeleteAsync(getUrl(url));
            return new HttpResponseWrapper<object>(null!, responseHTTP.IsSuccessStatusCode, responseHTTP);
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
        {
            var responseString = await httpResponse.Content.ReadAsStringAsync();

            _logger.LogInformation($"Json response : {responseString}");
            var res = JsonSerializer.Deserialize<T>(responseString, options);
            Guard.Against.Null(res, nameof(res));

            return res;
        }
    }
}
