using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Net.Http;

namespace Alpha.BrightSky;

public class BrightSkyClient : IBrightSkyClient
{
    private readonly HttpClient _httpClient;
    private readonly BrightSkySettings _settings;
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true
    };

    public BrightSkyClient(HttpClient httpClient, IOptions<BrightSkySettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
    }
    public async Task<CurrentWeatherResponseDto> GetCurrentWeatherAsync(double lat, double lon)
    {
       var endpoint = _settings.Endpoints["CurrentWeather"];
        var url = $"{endpoint}?lat={lat.ToString(System.Globalization.CultureInfo.InvariantCulture)}&lon={lon.ToString(System.Globalization.CultureInfo.InvariantCulture)}&units=dwd&tz=Europe/Berlin";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<CurrentWeatherResponseDto>(_jsonOptions);

        return result!;
    }
}
