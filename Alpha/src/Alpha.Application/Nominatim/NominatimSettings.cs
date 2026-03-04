using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alpha.Nominatim;

public class NominatimSettings
{
    [Required]
    [Url]
    public required Uri BaseUrl { get; set; }
    public required Dictionary<string, string> Endpoints { get; set; } = new();
}
