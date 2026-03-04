using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.BrightSky;

public interface IBrightSkyClient
{
    Task<CurrentWeatherResponseDto> GetCurrentWeatherAsync(double lat, double lon);
}

