using Microsoft.Extensions.Options;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alpha.BrightSky;

public class BrightSkyClientTests
{
    private readonly IBrightSkyClient _brightSkyClient;
    private readonly ITestOutputHelper _output;

    public BrightSkyClientTests(ITestOutputHelper output)
    {
        _output = output;
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.brightsky.dev/")
        };

        var settings = Options.Create(new BrightSkySettings
        {
            BaseUrl = new Uri("https://api.brightsky.dev/"),
            Endpoints = new Dictionary<string, string>
            {
                { "CurrentWeather", "current_weather" }
            }
        });

        _brightSkyClient = new BrightSkyClient(httpClient, settings);
    }

    [Fact]
    public async Task GetCurrentWeather_ShouldReturnData()
    {
        var result = await _brightSkyClient.GetCurrentWeatherAsync(51.96, 7.63);

        _output.WriteLine($"Station: {result.Sources[0].StationName}");
        _output.WriteLine($"Distanz: {result.Sources[0].Distance}m");
        _output.WriteLine($"Temperatur: {result.Weather.Temperature}°C");
        _output.WriteLine($"Condition: {result.Weather.Condition}");
        _output.WriteLine($"Wind: {result.Weather.WindSpeed10} km/h");
        _output.WriteLine($"Luftfeuchtigkeit: {result.Weather.RelativeHumidity}%");


        result.ShouldNotBeNull();
        result.Weather.ShouldNotBeNull();
        result.Weather.Temperature.ShouldNotBeNull();
        result.Sources.ShouldNotBeEmpty();
    }
}