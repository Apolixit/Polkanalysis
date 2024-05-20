using Microsoft.Extensions.Configuration;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using System.Net.Http.Json;

namespace Polkanalysis.Api.Service
{
    public class PolkanalysisApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IApiEndpoint _apiEndpoint;

        public PolkanalysisApiService(HttpClient httpClient, IApiEndpoint apiEndpoint)
        {
            _httpClient = httpClient;
            _apiEndpoint = apiEndpoint;

            _httpClient.BaseAddress = _apiEndpoint.ApiUri;
        }

        public async Task<GlobalStatsDto?> GetMacroStatsSumUpAsync() => 
            await _httpClient.GetFromJsonAsync<GlobalStatsDto>("/api/polkadot/stats/sumup");
    }
}
