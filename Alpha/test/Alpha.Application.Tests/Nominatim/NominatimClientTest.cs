using Alpha.Nominatim;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Shouldly;

namespace Alpha.Nominatim;

public class NominatimClientTests
{
    private readonly INominatimClient _nominatimClient;
    private readonly ITestOutputHelper _output;

    public NominatimClientTests(ITestOutputHelper output)
    {
        _output = output;

        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://nominatim.openstreetmap.org/")
        };
        httpClient.DefaultRequestHeaders.Add("User-Agent", "AlphaApp");

        var settings = Options.Create(new NominatimSettings
        {
            BaseUrl = new Uri("https://nominatim.openstreetmap.org/"),
            Endpoints = new Dictionary<string, string>
            {
                { "Search", "search" }
            }
        });

        _nominatimClient = new NominatimClient(httpClient, settings);
    }

    [Fact]
    public async Task Search_ShouldReturnLocations()
    {
        var result = await _nominatimClient.SearchAsync("Münster");

        result.ShouldNotBeNull();
        result.ShouldNotBeEmpty();

        foreach (var location in result)
        {
            _output.WriteLine($"{location.DisplayName} | lat: {location.Lat} | lon: {location.Lon}");
        }
    }
}