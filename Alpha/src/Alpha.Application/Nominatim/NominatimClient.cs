using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Alpha.Nominatim;

public class NominatimClient : INominatimClient
{
    private readonly HttpClient _httpClient;
    private readonly NominatimSettings _settings;

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true
    };

    public NominatimClient(HttpClient httpClient, IOptions<NominatimSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
        _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("AlphaApp/1.0 (jangruner@gmx.net)");
    }

    public async Task<List<NominatimLocationDto>> SearchAsync(string query)
    {
        var endpoint = _settings.Endpoints["Search"];
        var url = $"{endpoint}?q={Uri.EscapeDataString(query)}&format=json&limit=5";
       
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<List<NominatimLocationDto>>(_jsonOptions) ?? new List<NominatimLocationDto>();
        return result;

    }
}
