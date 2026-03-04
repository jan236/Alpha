using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.BrightSky;

public class WeatherSourceDto
{
    public int? Id { get; set; }
    public string? StationName { get; set; }
    public double? Distance { get; set; }

    public double? Lat { get; set; }
    public double? Lon { get; set; }
}
