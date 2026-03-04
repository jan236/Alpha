using System;
using System.Collections.Generic;
using System.Text;

namespace Alpha.BrightSky;

public class WeatherDataDto
{
    public DateTime Timestamp { get; set; }
    public double? Temperature { get; set; }
    public string? Condition { get; set; }
    public string? Icon { get; set; }
    public double? CloudCover { get; set; }
    public int? RelativeHumidity { get; set; }
    public double? PressureMsl { get; set; }
    public double WindSpeed10 { get; set; }
    public double? WindGustSpeed10 { get; set; }
    public int? WindDirection10 { get; set; }
    public double? Precipitation10 { get; set; }
    public int? Visibility { get; set; }

}
