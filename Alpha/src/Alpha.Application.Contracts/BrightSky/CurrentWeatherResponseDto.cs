using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.BrightSky;

public class CurrentWeatherResponseDto
{
    public WeatherDataDto Weather { get; set; } = new();
    public List<WeatherSourceDto> Sources { get; set; } = new();

}
