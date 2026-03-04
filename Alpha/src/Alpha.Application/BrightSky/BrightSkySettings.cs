using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alpha.BrightSky;

public class BrightSkySettings
{
    [Required]
    [Url]
    public required Uri BaseUrl { get; set; }

    public required Dictionary<string, string> Endpoints { get; set; } = new();
}
