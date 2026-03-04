using Alpha.BrightSky;
using Alpha.Nominatim;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alpha.Blazor.Components.Pages;

public partial class WeatherDashboard : ComponentBase
{
    [Inject] private IBrightSkyClient BrightSkyClient { get; set; } = default!;
    [Inject] private INominatimClient NominatimClient { get; set; } = default!;

    private string _searchQuery = string.Empty;
    private List<NominatimLocationDto> _locationSuggestions = new();
    private NominatimLocationDto? _selectedLocation;
    private CurrentWeatherResponseDto? _currentWeather;
    private bool _isLoadingLocations = false;
    private bool _isLoadingWeather = false;
    private System.Threading.Timer? _debounceTimer;

    private async Task OnSearchInput(string value)
    {
        _searchQuery = value;
        _debounceTimer?.Dispose();

        if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
        {
            _locationSuggestions = new();
            return;
        }

        _debounceTimer = new System.Threading.Timer(async _ =>
        {
            await InvokeAsync(async () =>
            {
                _isLoadingLocations = true;
                StateHasChanged();

                _locationSuggestions = await NominatimClient.SearchAsync(value);

                _isLoadingLocations = false;
                StateHasChanged();
            });
        }, null, 300, Timeout.Infinite);
    }

    private async Task OnLocationSelected(NominatimLocationDto location)
    {
        _selectedLocation = location;
        _locationSuggestions = new();
        _searchQuery = location.DisplayName ?? string.Empty;

        _isLoadingWeather = true;
        StateHasChanged();

        var lat = double.Parse(location.Lat!, System.Globalization.CultureInfo.InvariantCulture);
        var lon = double.Parse(location.Lon!, System.Globalization.CultureInfo.InvariantCulture);

        _currentWeather = await BrightSkyClient.GetCurrentWeatherAsync(lat, lon);

        _isLoadingWeather = false;
        StateHasChanged();
    }

    private string GetWeatherIconUrl(string? icon) =>
    $"https://cdn.jsdelivr.net/gh/basmilius/weather-icons@dev/production/fill/svg/{icon}.svg";
}